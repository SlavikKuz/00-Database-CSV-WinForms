using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TubeStore.Models;
using TubeStore.Services;

namespace TubeStore.Controllers
{
    public class TubeController : Controller
    {
        private IRepository<Tube> tubes;
        
        public TubeController(IRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        [HttpGet]
        public async Task<ActionResult<Tube>> Details(int tubeId)
        {
            Tube tube = await tubes.GetById(tubeId);
            return View(tube);
        }
    }
}
