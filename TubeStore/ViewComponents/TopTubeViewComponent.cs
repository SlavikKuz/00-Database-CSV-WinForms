using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.ViewComponents
{
    public class TopTubeViewComponent : ViewComponent
    {
        private readonly IGenericRepository<Tube> tubes;

        public TopTubeViewComponent(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        public IViewComponentResult Invoke()
        {
            ICollection<Tube> tubesList = tubes.FindAll(x=>x.IsTubeOfTheWeek);

            return View("TopTube", tubesList);
        }

    }
}
