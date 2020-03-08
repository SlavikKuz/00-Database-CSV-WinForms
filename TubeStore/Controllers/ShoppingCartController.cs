using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModalNofications;
using Newtonsoft.Json;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.Models.Cart;
using TubeStore.ViewModels;
using static ModalNofications.SupportModalClass;

namespace TubeStore.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ShoppingCartController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Invoice> invoices;
        private readonly IGenericRepository<ShippingAddress> shippingAddresses;
        private readonly IGenericRepository<Coupon> coupons;
        private readonly UserManager<Customer> userManager;
        private readonly IModalNotification modalNotification;
        private readonly ILogger<ShoppingCartController> logger;

        public ShoppingCartController(IGenericRepository<Tube> tubes, 
                                      IGenericRepository<Invoice> invoices,
                                      IGenericRepository<ShippingAddress> shippingAddresses,
                                      IGenericRepository<Coupon> coupons,
                                      UserManager<Customer> userManager,
                                      IModalNotification modalNotification,
                                      ILogger<ShoppingCartController> logger)
        {
            this.tubes = tubes;
            this.invoices = invoices;
            this.shippingAddresses = shippingAddresses;
            this.coupons = coupons;
            this.userManager = userManager;
            this.modalNotification = modalNotification;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> ReturnCart()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = HttpContext.Session.GetString("ShoppingCartId");
            List<ShoppingCartItem> sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    HttpContext.Session.GetString("ShoppingCartItems"));

            Tube tempTube;

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
                    Discount = tempTube.Discount,
                    Total = sessionList.Find(z => z.TubeId == id).Quantity * tempTube.Price
                });
            }

            shoppingCart.Coupon = await coupons.FindAsync(x => 
                                x.CouponName == HttpContext.Session.GetString("Coupon"));

            foreach (var item in shoppingCart.ShoppingCartItems)
            {
                shoppingCart.GrandTotal += item.Total - item.Total*item.Discount;
            }
            
            return View(shoppingCart);
        }
        
        public IActionResult AddToCart(int tubeId, int quantity)
        {
            ISession session = HttpContext.Session;

            string cartId;
            List<ShoppingCartItem> sessionList = new List<ShoppingCartItem>();

            if (session.GetString("ShoppingCartId") == null)
            {
                cartId = Guid.NewGuid().ToString();
                session.SetString("ShoppingCartId", cartId);
                session.SetString("Coupon", string.Empty);
                logger.LogInformation($"New Cart {cartId} created");
            }
            else
            {
                cartId = session.GetString("ShoppingCartId");

                if (session.GetString("ShoppingCartItems") != null)
                    sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));

                logger.LogInformation($"Cart picked up {cartId} and items");
            }

            if(sessionList.FindIndex(x => x.TubeId == tubeId) == -1)
            {
                sessionList.Add(new ShoppingCartItem()
                {
                    TubeId = tubeId,
                    Quantity = quantity
                });
                logger.LogInformation($"New item {tubeId} added to cart");
            }
            else
            {
                for (int i = 0; i < sessionList.Count(); i++)
                {
                    if (sessionList[i].TubeId == tubeId)
                    {
                        sessionList[i].Quantity += quantity;
                    }
                    logger.LogInformation($"{tubeId} added {quantity}");
                }
            }

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            return RedirectToAction("ReturnCart");
        }

        [HttpPost]
        public IActionResult Update(int[] quantity, string couponName)
        {
            ISession session = HttpContext.Session;

            List<ShoppingCartItem> sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                session.GetString("ShoppingCartItems"));

            for (int i = 0; i < quantity.Count(); i++)
            {
                sessionList[i].Quantity = quantity[i];
            }

            session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            if (String.IsNullOrEmpty(couponName))
                { couponName = string.Empty; }
            else
                { logger.LogInformation($"Coupon {couponName} applied"); }

            session.SetString("Coupon", couponName);

            return RedirectToAction("ReturnCart");
        }

        [HttpGet]
        public IActionResult Remove(int tubeId)
        {
            List<ShoppingCartItem> sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                HttpContext.Session.GetString("ShoppingCartItems"));

            int index = sessionList.FindIndex(x => x.TubeId == tubeId);

            sessionList.RemoveAt(index);
            logger.LogInformation($"Tube {tubeId} removed");

            HttpContext.Session.SetString("ShoppingCartItems", JsonConvert.SerializeObject(sessionList));

            return RedirectToAction("ReturnCart");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            Customer customer = await userManager.GetUserAsync(User);

            if (customer == null)
            {
                logger.LogInformation($"Checkout failed");
                modalNotification.AddNotificationSweet("Fail", NotificationType.error, "Please try later!");
                return RedirectToAction(nameof(ReturnCart));
            }

            ShippingAddress billingAddress = new ShippingAddress()
            {
                AddressLine1 = customer.AddressLine1,
                AddressLine2 = customer.AddressLine2,
                ZipCode = customer.ZipCode,
                City = customer.City,
                State = customer.State,
                Country = customer.Country
            };

            ShippingAddress shippingAddress = await shippingAddresses.FindAsync(
                x => x.CustomerId.Equals(customer.Id)) ?? new ShippingAddress();
            
            CheckoutViewModel model = new CheckoutViewModel();

            model.BillingAddress = billingAddress;
            model.ShippingAddress = shippingAddress;
            model.Customer = new CustomerViewModel()
            {
                CustomerId = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(CheckoutViewModel model)
        {
            ISession session = HttpContext.Session;
            Customer customer = await userManager.GetUserAsync(User);
            Tube tubeTemp;
            int adressId = 0;

            //update shipping, billing address in customer
            try
            {
                adressId = await UpdateCustomerAndAddresses(model);
            }
            catch(Exception ex)
            {
                logger.LogInformation(ex.Message);
                logger.LogInformation($"Failed updating customer and adresses");
            }

            if (adressId == 0)
            {
                logger.LogInformation($"Failed updating customer and adresses");
                return RedirectToAction(nameof(ReturnCart));
            }

            //new invoice
            Invoice invoice = new Invoice()
            {
                OrderDate = DateTime.Now,
                CustomerId = customer.Id,
                ShippingAddressId = adressId,
            };

            //get coupon
            string couponName = session.GetString("Coupon");
            Coupon coupon = await coupons.FindAsync(x => x.CouponName.Equals(couponName)) ?? new Coupon();
            if (coupon.CouponId != 0)
                invoice.CouponId = coupon.CouponId;

            //get shoppingcart items
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingCartId = session.GetString("ShoppingCartId");
            List<ShoppingCartItem> sessionList = JsonConvert.DeserializeObject<List<ShoppingCartItem>>(
                    session.GetString("ShoppingCartItems"));

            if(sessionList.Count()==0)
            {
                logger.LogInformation($"List in cart is empty???");
                return RedirectToAction(nameof(ReturnCart));
            }

            //get cartitems => to invoiceinfo in new invoice
            try
            {
                foreach (var item in sessionList)
                {
                    tubeTemp = await tubes.GetAsync(item.TubeId);

                    invoice.InvoicesInfo.Add(new InvoiceInfo()
                    {
                        TubeId = item.TubeId,
                        Price = tubeTemp.Price,
                        Quantity = item.Quantity,
                        Discount = tubeTemp.Discount
                    });
                }
            }
            catch(Exception ex)
            {
                logger.LogInformation($"Adding tubes to order failed");
                logger.LogInformation(ex.Message);
                modalNotification.AddNotificationSweet("Fail", NotificationType.error, "Please try later!");
            }

            //total cost for invoice
            foreach (var item in invoice.InvoicesInfo)
            {
                invoice.Total += item.Quantity * item.Price * (1 - item.Discount);
            }

            invoice.Total *= (1 - coupon.CouponValue);

            //saving invoice
            try
            {
            var invoiceResult = await invoices.AddAsync(invoice);
            }
            catch(Exception ex)
            {
                logger.LogInformation($"Inovice saving failed");
                logger.LogInformation(ex.Message);
                modalNotification.AddNotificationSweet("Fail", NotificationType.error, "Please try later!");
            }

            //decrease number of tubes in stock
            try
            {
                foreach (var item in invoice.InvoicesInfo)
                {
                    tubeTemp = await tubes.GetAsync(item.TubeId);
                    tubeTemp.Quantity -= item.Quantity;
                    var tubeResult = await tubes.UpdateAsync(tubeTemp);
                }
            }
            catch(Exception ex)
            {
                logger.LogInformation($"Tube minus quantity failed");
                logger.LogInformation(ex.Message);
                modalNotification.AddNotificationSweet("Fail", NotificationType.error, "Please try later!");
            }

            //clear shoppingcart 
            HttpContext.Session.Remove("ShoppingCartId");
            HttpContext.Session.Remove("ShoppingCartItems");

            modalNotification.AddNotificationSweet("Invoice", NotificationType.success, "Invoice created. Now you can pay it");

            return RedirectToAction(nameof(InvoiceController.Index), "Invoice");
        }

        public async Task<int> UpdateCustomerAndAddresses(CheckoutViewModel model)
        {
            Customer customer = await userManager.GetUserAsync(User);

            customer.AddressLine1 = model.BillingAddress.AddressLine1;
            customer.AddressLine2 = model.BillingAddress.AddressLine2;
            customer.ZipCode = model.BillingAddress.ZipCode;
            customer.City = model.BillingAddress.City;
            customer.State = model.BillingAddress.State;
            customer.Country = model.BillingAddress.Country;

            var result = await userManager.UpdateAsync(customer);

            if (!result.Succeeded)
            {
                logger.LogInformation($"Checkout failed");
                modalNotification.AddNotificationSweet("Fail", NotificationType.error, "Please try later!");
                return 0;
            }

            ShippingAddress shippingAddress = await shippingAddresses.FindAsync(x => x.CustomerId == customer.Id)
                ?? new ShippingAddress();

            if (model.IsTheSame)
            {
                shippingAddress.AddressLine1 = model.BillingAddress.AddressLine1;
                shippingAddress.AddressLine2 = model.BillingAddress.AddressLine2;
                shippingAddress.ZipCode = model.BillingAddress.ZipCode;
                shippingAddress.City = model.BillingAddress.City;
                shippingAddress.State = model.BillingAddress.State;
                shippingAddress.Country = model.BillingAddress.Country;
            }
            else
            {
                shippingAddress.AddressLine1 = model.ShippingAddress.AddressLine1;
                shippingAddress.AddressLine2 = model.ShippingAddress.AddressLine2;
                shippingAddress.ZipCode = model.ShippingAddress.ZipCode;
                shippingAddress.City = model.ShippingAddress.City;
                shippingAddress.State = model.ShippingAddress.State;
                shippingAddress.Country = model.ShippingAddress.Country;
            }

            if (shippingAddress.CustomerId == null)
            {
                shippingAddress.CustomerId = customer.Id;
                await shippingAddresses.AddAsync(shippingAddress);
            }
            else
            {
                await shippingAddresses.UpdateAsync(shippingAddress);
            }
            return shippingAddress.ShippingAdressId;
        }
    }
}