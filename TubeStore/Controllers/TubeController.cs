using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Controllers
{
    public class TubeController : Controller
    {   
        private readonly IGenericRepository<Tube> tubes;
        
        public TubeController(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        [HttpGet]
        public async Task<ActionResult<Tube>> Details(int tubeId)
        {
            Tube tube = await tubes.GetAllIncluding(x => x.Category).Where(x => x.TubeId == tubeId)
                .FirstOrDefaultAsync();
            
            return View(tube);
        }
    }
}
