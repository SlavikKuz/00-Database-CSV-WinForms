using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.ViewModels.Admin
{
    public class CarouselViewModel
    {
        public Carousel NewCarousel { get; set; }
        public ICollection<Carousel> Carousels { get; set; }
    }
}
