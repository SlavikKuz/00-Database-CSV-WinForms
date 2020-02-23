using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Tubes = tubes.GetAll(),
                Carousels = carousels.GetAll()
            };       
            
            return View(homeIndexViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Search(IFormCollection form)
        {
            string keyword = this.HttpContext.Request.Query["keyword"].ToString();

            string keyString = form["keyword"];
            string[] searchKeys = keyString.Split(' ');

            IEnumerable<Tube> temp;
            List<Tube> resultTemp = new List<Tube>();

            for (int i = 0; i < searchKeys.Count(); i++)
            {
                temp = await tubes.FindAllAsync(x => x.Brand.Contains(searchKeys[i]));

                foreach (var tube in temp)
                    resultTemp.Add(tube);

                temp = await tubes.FindAllAsync(x => x.Type.Contains(searchKeys[i]));

                foreach (var tube in temp)
                    resultTemp.Add(tube);

                temp = await tubes.FindAllAsync(x => x.ShortDescription.Contains(searchKeys[i]));

                foreach (var tube in temp)
                    resultTemp.Add(tube);
            }

            List<Tube> result = resultTemp.Distinct().ToList();
            
            return RedirectToAction("List", result);
        }

        public IActionResult List(int? page, List<Tube> result)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Tube>.CreateNonAsync(result,
                                                           pageNumber,
                                                           pageSize));
        }
    }
}