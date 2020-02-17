using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/login")]
    public class LoginController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;

        public LoginController(IGenericRepository<Tube> tubes)
        {
            this.tubes = tubes;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

    }
}