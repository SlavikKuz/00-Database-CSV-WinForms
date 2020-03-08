using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {

            private readonly IGenericRepository<Carousel> carousels;

            public CarouselViewComponent(IGenericRepository<Carousel> carousels)
            {
                this.carousels = carousels;
            }

        public IViewComponentResult Invoke()
        {
            ICollection<Carousel> carouselList = carousels.FindAll(x => x.Status);
            return View("Carousel", carouselList);
        }
    }
}
