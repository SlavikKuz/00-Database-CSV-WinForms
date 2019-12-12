using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.Models;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class TubeController : Controller
    {
        private readonly ITubeRepository tubeRepository;
        private readonly ICategoryRepository categoryRepository;
        
        public TubeController(ITubeRepository tubeRepository, ICategoryRepository categoryRepository)
        {
            this.tubeRepository = tubeRepository;
            this.categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Tube> tubes;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                tubes = tubeRepository.Tubes.OrderBy(x => x.TubeId);
                currentCategory = "All tubes";
            }
            else
            {
                tubes = tubeRepository.Tubes.Where(x => x.Category.CategoryName == category)
                    .OrderBy(x => x.TubeId);
                currentCategory = categoryRepository.Categories
                    .FirstOrDefault(x => x.CategoryName == category).CategoryName;
            }
            
            return View( new TubesListViewModel
            {
                Tubes = tubes,
                CurrentCategory = currentCategory
            });
        }
        
        public ActionResult Details(int id)
        {
            var tube = tubeRepository.GetTubeById(id);
            if (tube == null)
                return NotFound();

            return View(tube);
        }        
    }
}