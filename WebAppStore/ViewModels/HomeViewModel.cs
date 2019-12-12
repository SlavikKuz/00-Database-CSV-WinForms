using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Models;

namespace WebAppStore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Tube> TubesOfTheWeek { get; set; }
    }
}
