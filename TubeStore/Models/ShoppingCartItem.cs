using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class ShoppingCartItem
    {
        public int TubeId { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string TypeBrandDate { get; set; }
        public int Quantity { get; set; }
        public int QuantityLimit { get; set; }
        public decimal Price { get; set; }
    }
}
