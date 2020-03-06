using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels.Admin;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CarouselController : Controller
    {
        private readonly IGenericRepository<Carousel> carousels;
        private readonly IWebHostEnvironment hostEnvironment;

        public CarouselController(IGenericRepository<Carousel> carousels,
                                  IWebHostEnvironment hostEnvironment)
        {
            this.carousels = carousels;
            this.hostEnvironment = hostEnvironment;
        }
        
        [HttpGet]
        public async Task<IActionResult> EditCarousels()
        {
            CarouselViewModel model = new CarouselViewModel();
            model.Carousels = await carousels.GetAllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCarousels(CarouselViewModel carouselModel, IFormFile imageFile)
        {
            Carousel carousel = carouselModel.NewCarousel;
            carousel.ImageUrl = await UploadFile(imageFile);

            await carousels.AddAsync(carousel);

            return RedirectToAction("EditCarousels");
        }

        public async Task<string> UploadFile(IFormFile imageFile)
        {
            string path = Path.Combine("Images\\Carousel", imageFile.FileName);
            string fullPath = Path.Combine(hostEnvironment.WebRootPath, path);
            
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return string.Concat("\\",path);
        }

        public async Task<IActionResult> SetShow(int id)
        {
            Carousel carousel = await carousels.GetAsync(id);
            carousel.Status = !carousel.Status;
            await carousels.UpdateAsync(carousel);

            return RedirectToAction("EditCarousels");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Carousel carousel = await carousels.GetAsync(id);
            string path = Path.Combine(hostEnvironment.WebRootPath, carousel.ImageUrl.Remove(0, 1));
            
            //non safe method
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                await carousels.DeleteAsync(carousel);
            }

            return RedirectToAction("EditCarousels");
        }
    }
}