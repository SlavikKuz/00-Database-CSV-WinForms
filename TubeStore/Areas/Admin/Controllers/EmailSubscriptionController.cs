using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class EmailSubscriptionController : Controller
    {
        private readonly IGenericRepository<EmailSubscription> emailSubscriptions;
        private readonly UserManager<Customer> userManager;

        public EmailSubscriptionController(IGenericRepository<EmailSubscription> emailSubscriptions,
                                           UserManager<Customer> userManager)
        {
            this.emailSubscriptions = emailSubscriptions;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateMail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMail(string text)
        {
            var admin = await userManager.GetUserAsync(User);
            string adminEmail = await userManager.GetEmailAsync(admin);
            string subjEmail = "Mail from TubeStore" + DateTime.Now.ToShortDateString();
            var mailList = await emailSubscriptions.FindAllAsync(x => x.Status);

            MailMessage mail = new MailMessage();

            try
            {
                mail.From = new MailAddress(adminEmail);
                foreach (var email in mailList)
                {
                    mail.To.Add(new MailAddress(email.Email));
                }
                mail.Subject = subjEmail;
                mail.IsBodyHtml = true;
                mail.Body = text;
                
                SmtpClient smtp = new SmtpClient();
                smtp.Send(mail);
            }
            catch (Exception)
            {
                return RedirectToAction("CreateMail", text);
            }

            return View();
        }
    }
}