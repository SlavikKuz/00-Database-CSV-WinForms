using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;
using TubeStore.Models.Cart;

namespace TubeStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public List<Tube> ShoppingTubes { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
