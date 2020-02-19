using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Areas.Admin.Controllers
{
    
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;

        public HomeController(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}