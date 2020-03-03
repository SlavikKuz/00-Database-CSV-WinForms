using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ModalNofications;
using TubeStore.DataLayer;
using TubeStore.Hubs;
using TubeStore.Models;
using TubeStore.Models.Notification;
using static ModalNofications.SupportModalClass;

namespace TubeStore.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IGenericRepository<Invoice> invoices;
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Notification> notifications;
        private readonly IGenericRepository<NotificationUser> notificationUsers;
        private readonly UserManager<Customer> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IModalNotification modalNotification;
        private readonly IHubContext<ChatHub> chatHub;

        public InvoiceController(IGenericRepository<Invoice> invoices,
                                 IGenericRepository<Tube> tubes,
                                 IGenericRepository<Notification> notifications,
                                 IGenericRepository<NotificationUser> notificationUsers,
                                 UserManager<Customer> userManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IModalNotification modalNotification,
                                 IHubContext<ChatHub> chatHub
            )
        {
            this.invoices = invoices;
            this.tubes = tubes;
            this.notifications = notifications;
            this.notificationUsers = notificationUsers;
            this.userManager = userManager;
            this.modalNotification = modalNotification;
            this.chatHub = chatHub;
        }

        public async Task<IActionResult> Index()
        {

            Customer customer = userManager.Users.First(x => x.UserName == User.Identity.Name);

            IEnumerable<Invoice> customerInvoices = await
                invoices.FindAllAsync(x => x.CustomerId == customer.Id);
 
            return View(customerInvoices.Where(x=>!x.Status.Equals(EnumStatus.Cancelled)));
        }

        public async Task<IActionResult> Delete(int id)
        {
            Invoice invoice = invoices.GetIncluding(x => x.InvoiceId == id,
                    x => x.Customer,
                    x => x.ShippingAddress,
                    x => x.InvoicesInfo).First();

            invoice.Status = EnumStatus.Cancelled;
            await invoices.UpdateAsync(invoice);

            Tube tempTube;

            foreach (var item in invoice.InvoicesInfo)
            {
                tempTube = await tubes.GetAsync(item.TubeId);
                tempTube.Quantity += item.Quantity;
                await tubes.UpdateAsync(tempTube);
            }    
            return Ok();
            // return BadREquest();
            //catched exception in deletescript
        }

        public async Task<IActionResult> Details(int id)
        {
            Invoice invoice = invoices.GetIncluding(x => x.InvoiceId == id,
                    x => x.Customer,
                    x => x.ShippingAddress,
                    x => x.Coupon,
                    x => x.InvoicesInfo).First();

            for (int i = 0; i < invoice.InvoicesInfo.Count; i++)
            {
                invoice.InvoicesInfo[i].Tube = await tubes.GetAsync(invoice.InvoicesInfo[i].TubeId);
            }

            modalNotification.AddNotificationSweet("Nice", NotificationType.success, "You opened your invoices");


            return View(invoice);
        }

        public async Task<IActionResult> PayInvoce(int id)
        {
            Invoice invoice = await invoices.GetAsync(id);
            invoice.Status = EnumStatus.Paid;
            await invoices.UpdateAsync(invoice);

            Notification notification = new Notification()
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
                //chatHub.Clients.All.InvokeAsync("displayNotification", "");
            }

            return RedirectToAction("Index");
        }
    }
}