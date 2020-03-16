using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.ViewModels.Admin
{
    public class TableViewModel
    {
        public int TubeId { get; set; }
        public string UrlImageTube { get; set; }
        public string TubeName { get; set; }
        public decimal PriceTube { get; set; }
        public int SoldTubes { get; set; }
    }
}
