using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Models;

namespace WebAppStore.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext storeDbContext;
        private readonly ShoppingCart shoppingCart;

        public OrderRepository(StoreDbContext storeDbContext, ShoppingCart shoppingCart)
        {
            this.storeDbContext = storeDbContext;
            this.shoppingCart = shoppingCart;
        }
        
        
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            storeDbContext.Orders.Add(order);

            var shoppingcartItems = shoppingCart.ShoppingCartItems;

            foreach(var shoppingCartItem in shoppingcartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    TubeId = shoppingCartItem.Tube.TubeId,
                    OrderId = order.OrderId,
                    Price = shoppingCartItem.Tube.Price
                };

                storeDbContext.OrderDetails.Add(orderDetail);
            }

            storeDbContext.SaveChanges();
        }
    }
}
