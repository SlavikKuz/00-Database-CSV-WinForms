using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Models
{
    public class Carousel
    {
        public int CarouselId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TubeReferenceId { get; set; }
        public bool Status { get; set; }
    }
}
