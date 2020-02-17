using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<ShoppingCart> shoppingCarts;

        public ShoppingCartController(IGenericRepository<Tube> tubes, IGenericRepository<ShoppingCart> shoppingCarts)
        {
            this.tubes = tubes;
            this.shoppingCarts = shoppingCarts;
        }

        public async Task<ActionResult<ShoppingCart>> ReturnCart()
        {
            ISession session = this.HttpContext.Session;

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = session.GetString("ShoppingCartId");
            List<ShoppingCartItem> sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));

            Tube tempTube = null;

            foreach (int id in sessionList.Select(x => x.TubeId))
            {
                tempTube = await tubes.GetAsync(id);
                shoppingCart.ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    TubeId = tempTube.TubeId,
                    ImageThumbnailUrl = tempTube.ImageThumbnailUrl,
                    TypeBrandDate = tempTube.Type + " " + tempTube.Brand + ", " + tempTube.Date,
                    Quantity = sessionList.Find(z => z.TubeId == id).Quantity,
                    QuantityLimit = tempTube.Quantity,
                    Price = tempTube.Price,
                    Total = sessionList.Find(z => z.TubeId == id).Quantity * tempTube.Price
                });
            }

            foreach (var item in shoppingCart.ShoppingCartItems)
            {
                shoppingCart.GrandTotal += item.Total;
            }

            return View(shoppingCart);
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

                if (session.GetString("ShoppingCartItems") != null)
                    sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));
            }

            if(sessionList.FindIndex(x => x.TubeId == TubeId) == -1)
            {
                sessionList.Add(new ShoppingCartItem()
                {
                    TubeId = TubeId,
                    Quantity = Quantity
                });
            }
            else
            {
                for (int i = 0; i < sessionList.Count(); i++)
                {
                    if (sessionList[i].TubeId == TubeId)
                    {
                        sessionList[i].Quantity += Quantity;
                    }
                }
            }

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            return RedirectToAction("ReturnCart");
        }

        public async Task<ActionResult<ShoppingCart>> Update(int[] quantity)
        {
            ISession session = this.HttpContext.Session;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();

            sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                session.GetString("ShoppingCartItems"));

            for (int i = 0; i < quantity.Count(); i++)
            {
                sessionList[i].Quantity = quantity[i];
            }

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            return RedirectToAction("ReturnCart");
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

            return RedirectToAction("ReturnCart");
        }
    }
}