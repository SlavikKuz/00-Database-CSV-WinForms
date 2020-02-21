using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TubeStore.Areas.Admin.ViewModels;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public ActionResult Index()
        {
            IEnumerable<RoleViewModel> roleViewModel = roleManager.Roles.Select(
                x => new RoleViewModel()
                {
                    RoleId = x.Id,
                    RoleName = x.Name
                });

            return View(roleViewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(RoleViewModel roleViewModel)
        {
            try
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = roleViewModel.RoleName });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(string RoleName)
        {
            var result = await roleManager.FindByNameAsync(RoleName);
            RoleViewModel roleViewModel = new RoleViewModel()
            {
                RoleId = result.Id,
                RoleName = result.Name
            };

            return View(roleViewModel);
        }

        int c = 0;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string RoleId, string RoleName)
        {
            try
            {
                if(await roleManager.RoleExistsAsync(RoleName))
                {
                    ModelState.AddModelError("", "A role with this name already exists.");
                    return View();
                }
                else
                {
                    var role = await roleManager.FindByIdAsync(RoleId);
                    role.Name = RoleName;
                    role.NormalizedName = RoleName.ToUpper();
                    var result = await roleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Couldn't update the role.");
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(string RoleName)
        {
            try
            {
                if (!await roleManager.RoleExistsAsync(RoleName))
                {
                    ModelState.AddModelError("", "This role does not exist.");
                    return View();
                }
                else
                {
                    var role = await roleManager.FindByNameAsync(RoleName);
                    return View(new RoleViewModel() { RoleName = role.Name, RoleId = role.Id });
                }
            }
            catch (Exception)
            {
                //TO DO: log here
            }        
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string RoleId, IFormCollection collection)
        {
            try
            {
                var role = await roleManager.FindByIdAsync(RoleId);
                
                if(role!=null)
                {
                    var result = await roleManager.DeleteAsync(role);
                    
                    if(result.Succeeded)
                        return RedirectToAction(nameof(Index));
    
                    ModelState.AddModelError("", $"The {role.Name} could not be deleted.");
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}