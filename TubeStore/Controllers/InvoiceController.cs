using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using ModalNofications;
using TubeStore.DataLayer;
using TubeStore.Hubs;
using TubeStore.Models;
using TubeStore.Models.Notification;
using static ModalNofications.SupportModalClass;

namespace TubeStore.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class InvoiceController : Controller
    {
        private readonly IGenericRepository<Invoice> invoices;
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Notification> notifications;
        private readonly IGenericRepository<NotificationUser> notificationUsers;
        private readonly UserManager<Customer> userManager;
        private readonly IModalNotification modalNotification;
        private readonly ILogger<InvoiceController> logger;

        public InvoiceController(IGenericRepository<Invoice> invoices,
                                 IGenericRepository<Tube> tubes,
                                 IGenericRepository<Notification> notifications,
                                 IGenericRepository<NotificationUser> notificationUsers,
                                 UserManager<Customer> userManager,
                                 IModalNotification modalNotification,
                                 ILogger<InvoiceController> logger
            )
        {
            this.invoices = invoices;
            this.tubes = tubes;
            this.notifications = notifications;
            this.notificationUsers = notificationUsers;
            this.userManager = userManager;
            this.modalNotification = modalNotification;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Customer customer = await userManager.GetUserAsync(User);

            IEnumerable<Invoice> customerInvoices = await
                invoices.FindAllAsync(x => x.CustomerId == customer.Id);

            customerInvoices = customerInvoices.Where(x => !x.Status.Equals(EnumStatus.Cancelled));

            return View(customerInvoices);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Invoice invoice = invoices.GetIncluding(x => x.InvoiceId == id,
                                                    x => x.InvoicesInfo)
                                                    .First();

            invoice.Status = EnumStatus.Cancelled;

            try
            {
                var result = await invoices.UpdateAsync(invoice);
                logger.LogInformation($"Invoice {id} cancelled");
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                modalNotification.AddNotificationSweet("Invoice" + id.ToString(), NotificationType.warning, "Not cancelled!");
            }

            Tube tempTube;

            foreach (var item in invoice.InvoicesInfo)
            {
                tempTube = await tubes.GetAsync(item.TubeId);
                tempTube.Quantity += item.Quantity;
                await tubes.UpdateAsync(tempTube);
                logger.LogInformation($"Tube {tempTube.TubeId} returned {item.Quantity} to stock.");
            }

            modalNotification.AddNotificationSweet("Invoice" + id.ToString(), NotificationType.success, "Invoice cancelled!");

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Invoice invoice = invoices.GetIncluding(x => x.InvoiceId == id,
                    x => x.Customer,
                    x => x.ShippingAddress,
                    x => x.Coupon,
                    x => x.InvoicesInfo
                    ).First();

            ICollection<Tube> tubeList = await tubes.GetAllAsync();

            return View(invoice);
        }

        [HttpGet]
        public async Task<IActionResult> PayInvoce(int id)
        {
            Invoice invoice = await invoices.GetAsync(id);
            Notification notification;

            if (invoice==null)
            {
                logger.LogInformation($"Invoice {id} not found for payment");
                return RedirectToAction(nameof(Index));
            }
            else if (invoice.Status.Equals(EnumStatus.Paid))
            {
                modalNotification.AddNotificationSweet("Invoice" + id.ToString(), NotificationType.warning, "It is already paid!");
                logger.LogInformation($"User tried to pay Invoice {id} again");
                return RedirectToAction(nameof(Index));
            }
            
            invoice.Status = EnumStatus.Paid;

            try
            {
                var result = await invoices.UpdateAsync(invoice);
                logger.LogInformation($"Invoice {id} paid");
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex.Message);
                modalNotification.AddNotificationSweet("Invoice" + id.ToString(), NotificationType.error, "Not paid :(");
            }

            notification = new Notification()
            {
                NotificationText = $"The invoice {invoice.InvoiceId.ToString()} is paid."
            };

            await notifications.AddAsync(notification);
            var admins = await userManager.GetUsersInRoleAsync("Admin");

            foreach (var item in admins)
            {
                await notificationUsers.AddAsync(new NotificationUser 
                { 
                    CustomerId = item.Id, 
                    NotificationId = notification.NotificationId
                });
            }

            return RedirectToAction("Index");
        }
    }
}