using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public class ShoppingCart
    {
        private readonly StoreDbContext storeDbContext;
        private ShoppingCart(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>() ? .HttpContext.Session;

            var context = services.GetService<StoreDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart (Tube tube, int amount)
        {
            var shoppingCartItem = storeDbContext.ShoppingCartItems.SingleOrDefault(
                x => x.Tube.TubeId == tube.TubeId && x.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Tube = tube,
                    Amount = 1 //= amount
                };
            storeDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++; // + amount
            }
            storeDbContext.SaveChanges();
        }

        public int RemoveFromCart(Tube tube)
        {
            var shoppingCartItem = storeDbContext.ShoppingCartItems.SingleOrDefault(
                x => x.Tube.TubeId == tube.TubeId && x.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    storeDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
                storeDbContext.SaveChanges();
            }
                return localAmount;        
        }
    
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            // if cart empty get from database
            return ShoppingCartItems ?? (ShoppingCartItems = storeDbContext.ShoppingCartItems.Where(
                x => x.ShoppingCartId == ShoppingCartId).Include(c => c.Tube).ToList());
        }
    
        public void ClearCart()
        {
            var cartItems = storeDbContext.ShoppingCartItems.Where(
                                cart => cart.ShoppingCartId == ShoppingCartId);
            storeDbContext.ShoppingCartItems.RemoveRange(cartItems);
            storeDbContext.SaveChanges();
        }
    
        public decimal GetShoppingCartTotal()
        {
            var total = storeDbContext.ShoppingCartItems.Where(
                x => x.ShoppingCartId == ShoppingCartId).Select(x => x.Tube.Price * x.Amount).Sum();
            
            return total;
        }
    }
}
