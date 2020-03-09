using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CarouselController> logger;

        public CarouselController(IGenericRepository<Carousel> carousels,
                                  IWebHostEnvironment hostEnvironment,
                                  ILogger<CarouselController> logger)
        {
            this.carousels = carousels;
            this.hostEnvironment = hostEnvironment;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> EditCarousels()
        {
            CarouselViewModel model = new CarouselViewModel();
            model.Carousels = await carousels.GetAllAsync();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCarousels(CarouselViewModel carouselModel, IFormFile imageFile)
        {
            Carousel carousel = carouselModel.NewCarousel;

            try
            {
                carousel.ImageUrl = await UploadFile(imageFile);
                await carousels.AddAsync(carousel);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }

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
            return string.Concat("\\", path);
        }

        [HttpGet]
        public async Task<IActionResult> SetShow(int id)
        {
            Carousel carousel = await carousels.GetAsync(id);
            carousel.Status = !carousel.Status;

            try
            {
                await carousels.UpdateAsync(carousel);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }

            return RedirectToAction("EditCarousels");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Carousel carousel = await carousels.GetAsync(id);
            string path = Path.Combine(hostEnvironment.WebRootPath, carousel.ImageUrl.Remove(0, 1));

            //non safe method
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    await carousels.DeleteAsync(carousel);
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
            }

            return RedirectToAction("EditCarousels");
        }
    }
}