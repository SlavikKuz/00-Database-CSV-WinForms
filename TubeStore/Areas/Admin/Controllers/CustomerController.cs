using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TubeStore.Areas.Admin.ViewModels;
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

        public CustomerController(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
              
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

            CustomerViewModel customerViewModel = new CustomerViewModel()
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

            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Details(CustomerViewModel customerViewModel)
        {
            Customer customer = userManager.Users.First(x => x.Id == customerViewModel.CustomerId);
            List<IdentityRole> roles = roleManager.Roles.ToList();
            
            foreach (var item in customerViewModel.CustomerInRoles)
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
            return RedirectToAction("Details", new { customer.Id });
        }

        [HttpGet]
        public async Task<ActionResult> LockOut(string id)
        {          
            Customer customer = userManager.Users.First(x => x.Id == id);
            await userManager.SetLockoutEnabledAsync(customer, false);
            return RedirectToAction(nameof(Index));
        }
    }
}