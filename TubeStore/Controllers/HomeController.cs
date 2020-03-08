using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.Models.Chat;
using TubeStore.ViewModels;

namespace TubeStore.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;

        public HomeController(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> IndexCategory(string category, int? page, int? categoryId)
        {
            ICollection<Tube> tubesInCategory;

            if (categoryId != null)
                tubesInCategory = await tubes.FindAllAsync(x => x.Category.CategoryId == categoryId);
            else
                tubesInCategory = await tubes.FindAllAsync(x => x.Category.CategoryName == category);

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Tube>.CreateNonAsync(tubesInCategory,
                                                           pageNumber,
                                                           pageSize));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> IndexType(string type, int? page)
        {
            ICollection<Tube> tubesInCategory = await tubes.FindAllAsync(x => x.Type == type);

            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Tube>.CreateNonAsync(tubesInCategory,
                                                           pageNumber,
                                                           pageSize));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Search(IFormCollection form)
        {
            ISession session = HttpContext.Session;
            session.SetString("Search", form["search"]);

            return RedirectToAction("SearchList");
        }

        [AllowAnonymous]
        public async Task<IActionResult> SearchList(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Tube>.CreateNonAsync(await GetSearchingResult(),
                                                           pageNumber,
                                                           pageSize));
        }

        private async Task<List<Tube>> GetSearchingResult()
        {
            ISession session = this.HttpContext.Session;
            string[] searchKeys = session.GetString("Search").Split(' ');

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

            return resultTemp.Distinct().ToList();
        }

    }
}