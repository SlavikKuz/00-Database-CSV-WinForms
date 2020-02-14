using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TubeStore.Data;
using TubeStore.Models;
using TubeStore.Services;
using TubeStore.ViewModels;

namespace TubeStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IRepository<Tube> tubes;
        
        public ShoppingCartController(IRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        public async Task<ActionResult<ShoppingCart>> AddToCart(int TubeId, int Quantity)
        {
            ISession session = this.HttpContext.Session;

            string cartId = null;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();

            if (session.GetString("ShoppingCartId") == null)
            {
                cartId = Guid.NewGuid().ToString();
                session.SetString("ShoppingCartId", cartId);
            }
            else
            {
                cartId = session.GetString("ShoppingCartId");
                
                if(session.GetString("ShoppingCartItems") != null)
                    sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));                   
            }

            //if exists, increase nmuber
                sessionList.Add(new ShoppingCartItem()
                {
                    TubeId = TubeId,
                    Quantity = Quantity
                });

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = cartId;

            Tube tempTube = null;
            
            foreach (int id in sessionList.Select(x => x.TubeId))
            {
                tempTube = await tubes.GetById(id);
                shoppingCart.ShoppingCartItems.Add(new ShoppingCartItem() 
                {
                    TubeId = tempTube.TubeId,
                    ImageThumbnailUrl = tempTube.ImageThumbnailUrl,
                    TypeBrandDate = tempTube.Type + " " + tempTube.Brand + ", " + tempTube.Date,
                    Quantity = sessionList.Find(z => z.TubeId == id).Quantity,
                    QuantityLimit = tempTube.Quantity,
                    Price = tempTube.Price
                });
            }

            return View(shoppingCart);
        }

        public async Task<ActionResult<ShoppingCart>> Update(int[] quantity)
        {
            ISession session = this.HttpContext.Session;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();
            
            sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                session.GetString("ShoppingCartItems"));

            for(int i=0; i<quantity.Count(); i++)
            {
                sessionList[i].Quantity = quantity[i];
            }

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = session.GetString("ShoppingCartId");

            Tube tempTube = null;

            foreach (int id in sessionList.Select(x => x.TubeId))
            {
                tempTube = await tubes.GetById(id);
                shoppingCart.ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    TubeId = tempTube.TubeId,
                    ImageThumbnailUrl = tempTube.ImageThumbnailUrl,
                    TypeBrandDate = tempTube.Type + " " + tempTube.Brand + ", " + tempTube.Date,
                    Quantity = sessionList.Find(z => z.TubeId == id).Quantity,
                    QuantityLimit = tempTube.Quantity,
                    Price = tempTube.Price
                });
            }

            return View("AddToCart", shoppingCart);
        }

        public async Task<ActionResult<ShoppingCart>> Remove(int tubeId)
        {
            ISession session = this.HttpContext.Session;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();

            sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                session.GetString("ShoppingCartItems"));

            int index = sessionList.FindIndex(x => x.TubeId == tubeId);

            sessionList.RemoveAt(index);

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = session.GetString("ShoppingCartId");

            Tube tempTube = null;

            foreach (int id in sessionList.Select(x => x.TubeId))
            {
                tempTube = await tubes.GetById(id);
                shoppingCart.ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    TubeId = tempTube.TubeId,
                    ImageThumbnailUrl = tempTube.ImageThumbnailUrl,
                    TypeBrandDate = tempTube.Type + " " + tempTube.Brand + ", " + tempTube.Date,
                    Quantity = sessionList.Find(z => z.TubeId == id).Quantity,
                    QuantityLimit = tempTube.Quantity,
                    Price = tempTube.Price
                });
            }

            return View("AddToCart", shoppingCart);
        }
    }
}