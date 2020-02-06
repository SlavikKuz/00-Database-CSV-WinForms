using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.Models;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ITubeRepository tubeRepository;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(ITubeRepository tubeRepository, ShoppingCart shoppingCart)
        {
            this.tubeRepository = tubeRepository;
            this.shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int tubeId)
        {
            var selectedTube = tubeRepository.AllTubes.FirstOrDefault(p => p.TubeId == tubeId);

            if (selectedTube != null)
            {
                shoppingCart.AddToCart(selectedTube, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int tubeId)
        {
            var selectedTube = tubeRepository.AllTubes.FirstOrDefault(p => p.TubeId == tubeId);

            if (selectedTube != null)
            {
                shoppingCart.RemoveFromCart(selectedTube);
            }
            return RedirectToAction("Index");
        }

    }
}
