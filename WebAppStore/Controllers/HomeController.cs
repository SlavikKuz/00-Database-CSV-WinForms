using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppStore.Models;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITubeRepository tubeRepository;

        public HomeController(ITubeRepository tubeRepository)
        {
            this.tubeRepository = tubeRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                TubesOfTheWeek = tubeRepository.TubesOfTheWeek
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            return View();
        }    

    }
}
