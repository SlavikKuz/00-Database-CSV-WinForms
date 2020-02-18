using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        
        public int TubeId { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string TypeBrandDate { get; set; }
        public int Quantity { get; set; }
        public int QuantityLimit { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Total { get; set; }
    }
}
