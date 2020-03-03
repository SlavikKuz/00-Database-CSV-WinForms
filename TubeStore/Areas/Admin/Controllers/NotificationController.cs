using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TubeStore.DataLayer;
using TubeStore.Hubs;
using TubeStore.Models;
using TubeStore.Models.Notification;

namespace TubeStore.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IGenericRepository<Notification> notifications;
        private readonly IGenericRepository<NotificationUser> notificationUsers;
        private readonly UserManager<Customer> userManager;
        private readonly IHubContext<ChatHub> chatHub;
        
        public NotificationController(IGenericRepository<Notification> notifications,
                                      IGenericRepository<NotificationUser> notificationUsers,
                                      UserManager<Customer> userManager,
                                      IHubContext<ChatHub> chatHub)
        {
            this.notifications = notifications;
            this.notificationUsers = notificationUsers;
            this.userManager = userManager;
            this.chatHub = chatHub;
        }

        public IActionResult GetNotification()
        {
            string userId = userManager.GetUserId(User);

            List<NotificationUser> notification = notificationUsers.GetAllIncluding(x => x.Notification)
                .Where(x => x.CustomerId.Equals(userId))
                .ToList().Where(x => !x.IsRead).ToList();

            return Ok(new { UserNotification = notification, Count = notification.Count });
        }

        public async Task<IActionResult> ReadNotification(int notificationId)
        {
            string userId = userManager.GetUserId(User);

            NotificationUser notification = (
                await notificationUsers.FindAllAsync(x=> x.NotificationId.Equals(notificationId) &&
                x.CustomerId.Equals(userId))).ToList().FirstOrDefault();

            notification.IsRead = true;

            await notificationUsers.UpdateAsync(notification);

            return Ok();
        }
    }
}