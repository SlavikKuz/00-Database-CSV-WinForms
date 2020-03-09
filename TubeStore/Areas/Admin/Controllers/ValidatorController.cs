using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ValidatorController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;

        public ValidatorController(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyTubeName(string type, string brand)
        {
            var typeList = await tubes.FindAllAsync(x => x.Type.Equals(type));
            
            if (typeList.Count!=0)
                if (typeList.Where(x => x.Brand.Equals(brand)).Count() != 0)
                    return Json(false);
            
            return Json(true);
        }
    }
}