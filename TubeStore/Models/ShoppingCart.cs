using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Data;
using TubeStore.Services;

namespace TubeStore.Models
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } 
            = new List<ShoppingCartItem>();
    }
}
