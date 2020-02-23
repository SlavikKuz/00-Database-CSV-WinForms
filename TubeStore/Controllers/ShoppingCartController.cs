using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Invoice> invoices;
        private readonly IGenericRepository<ShippingAddress> shippingAddresses;
        private readonly UserManager<Customer> userManager;

        public ShoppingCartController(IGenericRepository<Tube> tubes, 
                                      IGenericRepository<Invoice> invoices,
                                      IGenericRepository<ShippingAddress> shippingAddresses,
                                      UserManager<Customer> userManager)
        {
            this.tubes = tubes;
            this.invoices = invoices;
            this.shippingAddresses = shippingAddresses;
            this.userManager = userManager;
        }

        public async Task<ActionResult<ShoppingCart>> ReturnCart()
        {
            ISession session = this.HttpContext.Session;

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = session.GetString("ShoppingCartId");
            List<ShoppingCartItem> sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));

            Tube tempTube = null;

            foreach (int id in sessionList.Select(x => x.TubeId))
            {
                tempTube = await tubes.GetAsync(id);
                shoppingCart.ShoppingCartItems.Add(new ShoppingCartItem()
                {
                    TubeId = tempTube.TubeId,
                    ImageThumbnailUrl = tempTube.ImageThumbnailUrl,
                    TypeBrandDate = tempTube.Type + " " + tempTube.Brand + ", " + tempTube.Date,
                    Quantity = sessionList.Find(z => z.TubeId == id).Quantity,
                    QuantityLimit = tempTube.Quantity,
                    Price = tempTube.Price,
                    Total = sessionList.Find(z => z.TubeId == id).Quantity * tempTube.Price
                });
            }

            foreach (var item in shoppingCart.ShoppingCartItems)
            {
                shoppingCart.GrandTotal += item.Total;
            }

            return View(shoppingCart);
        }
                
        public async Task<ActionResult<ShoppingCart>> AddToCart(int TubeId, int Quantity)
        {
            ISession session = this.HttpContext.Session;

            string cartId = null;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();

            if (session.GetString("ShoppingCartId") == null)
            {
                cartId = Guid.NewGuid().ToString();
                session.SetString("ShoppingCartId", cartId);
            }
            else
            {
                cartId = session.GetString("ShoppingCartId");

                if (session.GetString("ShoppingCartItems") != null)
                    sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));
            }

            if(sessionList.FindIndex(x => x.TubeId == TubeId) == -1)
            {
                sessionList.Add(new ShoppingCartItem()
                {
                    TubeId = TubeId,
                    Quantity = Quantity
                });
            }
            else
            {
                for (int i = 0; i < sessionList.Count(); i++)
                {
                    if (sessionList[i].TubeId == TubeId)
                    {
                        sessionList[i].Quantity += Quantity;
                    }
                }
            }

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            return RedirectToAction("ReturnCart");
        }

        public async Task<ActionResult<ShoppingCart>> Update(int[] quantity)
        {
            ISession session = this.HttpContext.Session;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();

            sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                session.GetString("ShoppingCartItems"));

            for (int i = 0; i < quantity.Count(); i++)
            {
                sessionList[i].Quantity = quantity[i];
            }

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            return RedirectToAction("ReturnCart");
        }

        public async Task<ActionResult<ShoppingCart>> Remove(int tubeId)
        {
            ISession session = this.HttpContext.Session;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();

            sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                session.GetString("ShoppingCartItems"));

            int index = sessionList.FindIndex(x => x.TubeId == tubeId);

            sessionList.RemoveAt(index);

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            return RedirectToAction("ReturnCart");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            Customer customer = userManager.Users.First(x => x.UserName == this.User.Identity.Name);

            if (customer == null)
                return RedirectToAction("Login", "Home"); 
                                
            CheckoutViewModel checkoutViewModel = new CheckoutViewModel();

            checkoutViewModel.BillingAddress = new ShippingAddress()
            {
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                ZipCode = customer.ZipCode,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                CustomerId = customer.Id
            };

            checkoutViewModel.ShippingAddress = 
                await shippingAddresses.FindAsync(x => x.CustomerId == customer.Id) ?? new ShippingAddress();

            checkoutViewModel.Customer = new CustomerViewModel()
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.PhoneNumber
            };

            return View(checkoutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(CheckoutViewModel checkoutViewModel)
        {
            Customer customer = await userManager.FindByIdAsync(checkoutViewModel.Customer.CustomerId);
            customer.Id = checkoutViewModel.Customer.CustomerId;
            customer.AddressLine1 = checkoutViewModel.BillingAddress.AddressLine1;
            customer.AddressLine2 = checkoutViewModel.BillingAddress.AddressLine2;
            customer.ZipCode = checkoutViewModel.BillingAddress.ZipCode;
            customer.City = checkoutViewModel.BillingAddress.City;
            customer.State = checkoutViewModel.BillingAddress.State;
            customer.Country = checkoutViewModel.BillingAddress.Country;
            
            var result = await userManager.UpdateAsync(customer);

            if (!result.Succeeded) return RedirectToAction("ReturnCart");

            ShippingAddress shippingAddress = new ShippingAddress();

            if (checkoutViewModel.IsTheSame)
                shippingAddress = checkoutViewModel.BillingAddress;
            else
                shippingAddress = checkoutViewModel.ShippingAddress;

            shippingAddress.CustomerId = customer.Id;

            if (await shippingAddresses.FindAsync(x => x.CustomerId == customer.Id) == null)
                await shippingAddresses.AddAsync(shippingAddress);
            else
                await shippingAddresses.UpdateAsync(shippingAddress);

            Invoice invoice = new Invoice()
            {
                OrderDate = DateTime.Now,
                CustomerId = customer.Id,
                ShippingAddressId = shippingAddress.ShippingAdressId
            };

            ISession session = this.HttpContext.Session;

            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = session.GetString("ShoppingCartId");
            List<ShoppingCartItem> sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));

            Tube tubeTemp;

            foreach (var item in sessionList)
            {
                tubeTemp = await tubes.GetAsync(item.TubeId);

                invoice.InvoicesInfo.Add(new InvoiceInfo()
                {
                    TubeId = item.TubeId,
                    Price = tubeTemp.Price,
                    Quantity = item.Quantity
                    //Type Brand
                    //thumb
                    //Discount
                    //shortdescr
                });
                tubeTemp.Quantity -= item.Quantity;
                await tubes.UpdateAsync(tubeTemp);
            }

            foreach (var item in invoice.InvoicesInfo)
            {
                invoice.Total += item.Quantity * item.Price;
                // ?? dicount
            }

            await invoices.AddAsync(invoice);
            HttpContext.Session.Remove("ShoppingCartId");
            HttpContext.Session.Remove("ShoppingCartItems");

            //coupon in the cart;
            //dicount in the cart
            //discount in infos 

            //dicount into info and badge

            return RedirectToAction("Index", "Invoice");
        }
    }
}