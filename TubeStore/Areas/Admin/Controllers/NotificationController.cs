using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.Models.Notification;

namespace TubeStore.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IGenericRepository<Notification> notifications;
        private readonly IGenericRepository<NotificationUser> notificationUsers;
        private readonly UserManager<Customer> userManager;
        
        public NotificationController(IGenericRepository<Notification> notifications,
                                      IGenericRepository<NotificationUser> notificationUsers,
                                      UserManager<Customer> userManager)
        {
            this.notifications = notifications;
            this.notificationUsers = notificationUsers;
            this.userManager = userManager;
        }

        public IActionResult GetNotification()
        {
            string userId = userManager.GetUserId(HttpContext.User);
            List<NotificationUser> notification = notificationUsers.GetAllIncluding(x=>x.Notification)
                .Where(x=>x.NotificationUserId.Equals(userId) && !x.IsRead)
                .ToList();

            return Ok(new { UserNotification = notification, Count = notification.Count });
        }

        public async Task<IActionResult> ReadNotification(int notificationId)
        {
            NotificationUser notification = (await notificationUsers.FindAllAsync(x=> x.NotificationId.Equals(notificationId) &&
                x.ChatUserId.Equals(HttpContext.User))).ToList().FirstOrDefault();

            notification.IsRead = true;

            await notificationUsers.UpdateAsync(notification);

            return Ok();
        }
    }
}