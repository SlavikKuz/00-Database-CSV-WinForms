using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Services;

namespace TubeStore.Models
{
    public class ShoppingCart
    {
    //    private readonly IRepository<Tube> tubes;
    //    public ShoppingCart(IRepository<Tube> tubes)
    //    {
    //        this.tubes = tubes;
    //    }

    //    public string ShoppingCartId { get; set; }
    //    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    //    public static ShoppingCart GetCart(IServiceProvider services)
    //    {
    //        ISession session = services.GetRequiredService<IHttpContextAccessor>() ?
    //            .HttpContext.Session;

    //        var context = services.GetService<TubeStoreDbContext>();
    //        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
    //        session.SetString("CartId", cartId);

    //        return new ShoppingCart(context) { ShoppingCartId = cartId };
    //    }

    }
}
