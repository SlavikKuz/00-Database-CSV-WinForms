using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Areas.Admin.ViewModels;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CategoryController:Controller
    {
        private readonly IGenericRepository<Category> categories;
        
        public CategoryController(IGenericRepository<Category> categories)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            List<Category> categoryList = categories.GetAllIncluding(x => x.Parents).ToList();
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(CategoryViewModel categoryViewModel)
        {
            try
            {
                await categories.AddAsync(new Category() { 
                    CategoryName = categoryViewModel.CategoryName,
                    Parent = null
                });

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddSub(int id)
        {

        }
    }
}
