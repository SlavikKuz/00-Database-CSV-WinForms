using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TubeStore.Areas.Admin.ViewModels;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class TubeController : Controller
    {
        private IGenericRepository<Tube> tubes;
        private IGenericRepository<Category> categories;
        private IWebHostEnvironment hostEnvironment;

        public TubeController(IGenericRepository<Tube> tubes,
            IGenericRepository<Category> categories,
            IWebHostEnvironment hostEnvironment)
        {
            this.tubes = tubes;
            this.categories = categories;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            List<Tube> allTubes = tubes.GetAllIncluding(x => x.Category).ToList();            
            return View(allTubes);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<ActionResult<TubeViewModel>> Edit(int tubeId)
        {
            TubeViewModel tubeViewModel = new TubeViewModel();
            tubeViewModel.Tube = await tubes.GetAsync(tubeId);
            tubeViewModel.CategoriesList = await GetCategoriesList();
            return View(tubeViewModel);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<ActionResult<Tube>> Edit(Tube tube)
        {
            await tubes.UpdateAsync(tube);
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        [Route("Add")]
        public async Task<ActionResult<TubeViewModel>> Add()
        {
            TubeViewModel tubeViewModel = new TubeViewModel();
            tubeViewModel.Tube = new Tube();
            tubeViewModel.CategoriesList = await GetCategoriesList();
            return View(tubeViewModel);
        }

        public async Task<List<SelectListItem>> GetCategoriesList ()
        {
            List<SelectListItem> categoriesList = new List<SelectListItem>();
            ICollection<Category> categoryList = await categories.GetAllAsync();
            foreach(var cat in categoryList)
            {
                categoriesList.Add(new SelectListItem()
                {
                    Text = cat.CategoryName,
                    Value = cat.CategoryId.ToString()
                });
            }
            return categoriesList;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<Tube>> Add(Tube tube, IFormFile image, IFormFile thumb)
        {
            tube.ImageUrl = await UploadAndGetPath(tube, image);
            tube.ImageThumbnailUrl = await UploadAndGetPath(tube, thumb);

            if (tube.Quantity > 0) tube.InStock = true;

            await tubes.AddAsync(tube);

            return RedirectToAction("Index");
        }

        public async Task<string> UploadAndGetPath(Tube tube, IFormFile image)
        {
            Category category = await categories.GetAsync(tube.CategoryId);

            var categoryPath = Path.Combine(hostEnvironment.WebRootPath, "Images", category.CategoryName);
             
            if (!Directory.Exists(categoryPath))
                Directory.CreateDirectory(categoryPath);
            
            var typePath = Path.Combine(categoryPath, tube.Type);

            if (!Directory.Exists(typePath))
                Directory.CreateDirectory(typePath);

            var imagePath = Path.Combine(typePath, image.FileName);
            var fileStream = new FileStream(imagePath, FileMode.Create);
            await image.CopyToAsync(fileStream);

            return imagePath;
        }
    }
}