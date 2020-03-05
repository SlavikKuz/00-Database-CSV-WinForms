using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.ViewComponents
{
    public class NewArrivalsViewComponent : ViewComponent
    {
        private readonly IGenericRepository<Tube> tubes;

        public NewArrivalsViewComponent(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        public IViewComponentResult Invoke()
        {
            ICollection<Tube> tubeList = tubes.FindAll(x => x.IsNewArrival);

            return View("NewArrivals", tubeList);
        }


    }
}
