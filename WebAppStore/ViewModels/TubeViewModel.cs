using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.ViewModels
{
    public class TubeViewModel
    {
        public int TubeId { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Parameters { get; set; }

        public decimal Price { get; set; }
        public string ImageThumbnailUrl { get; set; }
    }
}
