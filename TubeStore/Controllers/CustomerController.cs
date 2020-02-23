using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
                UserName = model.Login,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(customer, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(customer, false);
                await userManager.AddToRoleAsync(customer, "User");

                return RedirectToAction("Login");
            }
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
        public IActionResult CompleteRegisration(string username)
        {
            CustomerDetailsViewModel customerDetails = new CustomerDetailsViewModel() { UserName = username };
            return View(customerDetails);
        }
        
        [HttpPost]
        public async Task<IActionResult> CompleteRegisration(string username, CustomerDetailsViewModel customerDetails)
        {

            if (!ModelState.IsValid)
                return RedirectToAction("CompleteRegisration");

            Customer customer = await userManager.FindByNameAsync(username);

            customer.FirstName = customerDetails.FirstName;
            customer.LastName = customerDetails.LastName;
            customer.AddressLine1 = customerDetails.AddressLine1;
            customer.AddressLine2 = customerDetails.AddressLine2;
            customer.ZipCode = customerDetails.ZipCode;
            customer.City = customerDetails.City;
            customer.State = customerDetails.State;
            customer.Country = customerDetails.Coutry;
            customer.PhoneNumber = customerDetails.PhoneNumber;

            var result = await userManager.UpdateAsync(customer);

            if (result.Succeeded)
            {
            return RedirectToAction("Login", "Customer");
            }
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
                    return RedirectToAction("Index", "Home");
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
                HttpContext.Session.Remove("ShoppingCartItems");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Authorize(Roles="User, Admin")]
        public IActionResult Profile()
        {
            var user = userManager.Users.First(x => x.UserName == User.Identity.Name);
            return View( new CustomerViewModel
                {
                CustomerId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.PhoneNumber
            });
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Profile(CustomerViewModel customerViewModel)
        {
            if(ModelState.IsValid)
            {
                var user = userManager.Users.First(x => x.UserName == User.Identity.Name);
                user.FirstName = customerViewModel.FirstName;
                user.LastName = customerViewModel.LastName;
                user.Email = customerViewModel.Email;
                user.NormalizedEmail = customerViewModel.Email.ToUpper();
                user.PhoneNumber = customerViewModel.Phone;

                var result = await userManager.UpdateAsync(user);
                if(result.Succeeded)
                {
                    ViewData["Message"] = "Profile updated";
                }
                else
                {
                    ViewData["Message"] = "Updating Error";
                }
            }
           return View();
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByNameAsync(User.Identity.Name);
                    var result = await userManager.ChangePasswordAsync(user, 
                        changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);

                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");

                    ModelState.AddModelError("", "Password can not be changed");
                    return View();
                }
                ModelState.AddModelError("", "Invalid data");
                return View();
            }
            catch (Exception)
            {
                ModelState.AddModelError("","Error. Password was not changed");
                return View(); ;
            }
           
        }
    }
}