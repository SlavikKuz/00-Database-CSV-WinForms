using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;

namespace TubeStore.Models.Cart
{
    public class ShoppingCart
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } 
            = new List<ShoppingCartItem>();

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal GrandTotal { get; set; }

        public virtual Coupon Coupon { get; set; }
    }
}
