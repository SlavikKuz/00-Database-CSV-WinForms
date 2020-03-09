using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly ILogger<CategoryController> logger;

        public CategoryController(IGenericRepository<Category> categories,
                                  ILogger<CategoryController> logger)
        {
            this.categories = categories;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Index(int? page)
        {
            var roughList = await categories.GetAllAsync();
            var topCategories = roughList.Where(x => x.ParentId == null).ToList();
            var completeList = GetRecursively(roughList, topCategories);

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(PaginatedList<Category>.CreateNonAsync(completeList,
                                                               pageNumber,
                                                               pageSize));
        }

        private ICollection<Category> GetRecursively(ICollection<Category> roughList, 
                                                ICollection<Category> topCategories)
        {
            foreach (var topCat in topCategories)
            {
                foreach(var cat in roughList)
                {
                    if (cat.ParentId == topCat.CategoryId)
                        topCat.Parents.Add(cat);
                }

                if(topCat.Parents.Count>0)
                    topCat.Parents = GetRecursively(roughList, topCat.Parents);
            }
            return topCategories;
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
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddSub(int id)
        {
            Category subCategory = new Category() { ParentId = id };
            return View(subCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSub(int categoryId, Category subCategory)
        {
            await categories.AddAsync(subCategory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
            Category category = await categories.FindAsync(x => x.CategoryId == id);
            await categories.DeleteAsync(category);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View (await categories.FindAsync(x => x.CategoryId == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            Category update = await categories.FindAsync(x => x.CategoryId == category.CategoryId);
            update.CategoryName = category.CategoryName;
            update.ParentId = category.ParentId;

            await categories.UpdateAsync(update);
            return RedirectToAction("Index");
        }
    }
}
