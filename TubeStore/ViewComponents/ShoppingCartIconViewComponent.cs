using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;
using TubeStore.Models.Cart;

namespace TubeStore.ViewComponents
{
    [ViewComponent(Name = "ShoppingCartIcon")]
    public class ShoppingCartIconViewComponent : ViewComponent
        
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = HttpContext.Session.GetString("ShoppingCartId");
            
            if (shoppingCart.ShoppingCartId != null)
            shoppingCart.ShoppingCartItems = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    HttpContext.Session.GetString("ShoppingCartItems"));

            return View("CartIcon", shoppingCart);
        }
    }
}
