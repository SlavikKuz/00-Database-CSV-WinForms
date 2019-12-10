using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Models;

namespace WebAppStore.ViewModels
{
    public class TubesListViewModel
    {
        public IEnumerable<Tube> Tubes { get; set; }
        public string CurrentCategory { get; set; }
    }
}
