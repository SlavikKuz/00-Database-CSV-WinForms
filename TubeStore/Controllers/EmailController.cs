using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModalNofications;
using TubeStore.DataLayer;
using TubeStore.Models;
using static ModalNofications.SupportModalClass;

namespace TubeStore.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class EmailController : Controller
    {
        private readonly IGenericRepository<EmailSubscription> emailSubscriptions;
        private readonly IModalNotification modalNotification;
        private readonly ILogger<EmailController> logger;

        public EmailController(IGenericRepository<EmailSubscription> emailSubscriptions,
                               IModalNotification modalNotification,
                               ILogger<EmailController> logger)
        {
            this.emailSubscriptions = emailSubscriptions;
            this.modalNotification = modalNotification;
            this.logger = logger;
        }

        private static MailAddress getAddress(string address)
        {
            if (address == null) throw new ArgumentNullException("address");
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("invalid address", "address");

            address = address.Trim();
            return new MailAddress(address);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> AddEmail(string email)
        {
            MailAddress emailAddress;
            try
            {
                emailAddress = getAddress(email);
                logger.LogInformation($"Email {emailAddress.Address} added to list");

                var emailCheck = await emailSubscriptions.FindAsync(x => x.Email.Equals(emailAddress.Address));

                if (emailCheck == null)
                {
                    emailCheck = new EmailSubscription()
                    {
                        Email = emailAddress.Address,
                        Status = true
                    };
                    await emailSubscriptions.AddAsync(emailCheck);
                }
                else if (!emailCheck.Status)
                {
                    emailCheck.Status = true;
                    await emailSubscriptions.UpdateAsync(emailCheck);
                }
                modalNotification.AddNotificationSweet("Email", NotificationType.success, "You subscribed to the list!");
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch
            {
                logger.LogInformation($"Failed adding email to list");
                modalNotification.AddNotificationSweet("Fail", NotificationType.error, "Please check your email!");
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Unsubscribe(string email)
        {
            EmailSubscription emailAddress = await emailSubscriptions.FindAsync(x => x.Email.Equals(email));

            if(emailAddress == null)
            {
                modalNotification.AddNotificationSweet("Email", NotificationType.success, "You unbscribed from the list!");
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            emailAddress.Status = false;

            try
            {
                await emailSubscriptions.UpdateAsync(emailAddress);               
                logger.LogInformation($"Email {emailAddress.Email} unsubscribed");
            }
            catch
            {
                logger.LogInformation($"Failed unsubscribe email from list");
                modalNotification.AddNotificationSweet("Fail", NotificationType.error, "Unsubscribe failed!");
                RedirectToAction(nameof(HomeController.Index), "Home");
            }

            modalNotification.AddNotificationSweet("Email", NotificationType.success, "You unsunbscribed from the list!");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}