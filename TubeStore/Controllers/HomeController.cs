using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Carousel> carousels;

        public HomeController(IGenericRepository<Tube> tubes, IGenericRepository<Carousel> carousels)
        {
            this.tubes = tubes;
            this.carousels = carousels;
        }
     
        public IActionResult Index()
        {
            HomeIndexViewModel hivm = new HomeIndexViewModel()
            {
                Tubes = tubes.GetAll(),
                Carousels = carousels.GetAll()
            };       
            
            return View(hivm);
        }

        [HttpGet]
        public IActionResult AddTube()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddTube(Tube tube)
        {
            if (ModelState.IsValid)
            {
                //Tube item = new Tube()
                //{
                //    TubeId = tubes.GetAll().Max(x => x.TubeId) + 1,
                //    Type = tube.Type,
                //    Brand = tube.Brand,
                //    Date = tube.Date,
                //    ShortDescription = tube.ShortDescription,
                //    FullDescription = tube.FullDescription,
                //    MatchedPair = tube.MatchedPair,
                //    Price = tube.Price,
                //    Quantity = tube.Quantity,
                //    ImageUrl = tube.ImageUrl,
                //    ImageThumbnailUrl = tube.ImageThumbnailUrl,
                //    IsTubeOfTheWeek = tube.IsTubeOfTheWeek,
                //    InStock = tube.InStock,
                //    CategoryId = tube.CategoryId
                //};
                //tubes.(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}