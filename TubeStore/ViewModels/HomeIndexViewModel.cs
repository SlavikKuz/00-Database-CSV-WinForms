using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models;

namespace TubeStore.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Tube> Tubes { get; set; }
        public IEnumerable<Carousel> Carousels { get; set; }
    }
}
