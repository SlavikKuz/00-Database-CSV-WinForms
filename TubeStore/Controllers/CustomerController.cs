using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly ILogger<CustomerController> logger;
        private readonly SignInManager<Customer> signInManager;

        public CustomerController(UserManager<Customer> userManager, 
                                  ILogger<CustomerController> logger,
                                  SignInManager<Customer> signInManager)
        {
            this.userManager = userManager;
            this.logger = logger;
            this.signInManager = signInManager;
        }
               
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CustomerRegistrationViewModel model)
        {
            if (!ModelState.IsValid) 
                return RedirectToAction("Register");

            Customer customer = new Customer()
            {
                Email = model.Email
            };

            var result = await userManager.CreateAsync(customer, model.Password);

            if (result.Succeeded)
                return RedirectToAction("Cabinet");
            else 
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError("", error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CustomerLoginViewModel model)
        {
            if (!ModelState.IsValid) 
                return RedirectToAction("Login");

            var result = await signInManager.PasswordSignInAsync(
                model.EmailOrLogin, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                if (Request.Query.Keys.Contains("ReturnUrl"))
                    return Redirect(Request.Query["ReturnUrl"].FirstOrDefault());
                else
                    return RedirectToAction("Login");
            }
            else
            {
                ModelState.TryAddModelError("", "Failed to login");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if(User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
            }
            return View();
        }




    }
}