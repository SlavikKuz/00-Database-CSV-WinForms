using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TubeStore.ViewModels.Admin;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<CustomerController> logger;

        public CustomerController(UserManager<Customer> userManager, 
                                  RoleManager<IdentityRole> roleManager,
                                  ILogger<CustomerController> logger)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            var customers = userManager.Users.Select(
                x => new CustomerViewModel
                {
                    CustomerId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Login = x.UserName
                });

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(await PaginatedList<CustomerViewModel>.CreateAsync(customers,
                                                                 pageNumber,
                                                                 pageSize));
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            Customer customer = userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            List<IdentityRole> roles = roleManager.Roles.ToList();
            List<string> userRoles = (await userManager.GetRolesAsync(customer)).ToList();

            CustomerViewModel model = new CustomerViewModel()
            {
                CustomerId = customer.Id,
                Login = customer.UserName,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.PhoneNumber,
                CustomerInRoles = roles.Select(x => new RoleViewModel()
                {
                    RoleId = x.Id,
                    RoleName = x.Name,
                    Selected = userRoles.Exists(y => y == x.Name)
                }
                ).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Details(CustomerViewModel model)
        {
            Customer customer = userManager.Users.First(x => x.Id == model.CustomerId);
            List<IdentityRole> roles = roleManager.Roles.ToList();

            try
            {
                foreach (var item in model.CustomerInRoles)
                {
                    if (item.Selected)
                    {
                        await userManager.AddToRoleAsync(customer, roles.First(x => x.Id == item.RoleId).Name);
                    }
                    else
                    {
                        await userManager.RemoveFromRoleAsync(customer, roles.First(x => x.Id == item.RoleId).Name);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
            }

            return RedirectToAction("Details", new { customer.Id });
        }

        [HttpGet]
        public async Task<ActionResult> LockOut(string id)
        {          
            Customer customer = userManager.Users.First(x => x.Id == id);
            try 
            { 
                await userManager.SetLockoutEnabledAsync(customer, false);
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}