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
using TubeStore.Models.Chat;
using TubeStore.Models.Notification;

namespace TubeStore.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IGenericRepository<Notification> notifications;
        private readonly IGenericRepository<NotificationUser> notificationUsers;
        private readonly IGenericRepository<ChatGroup> chatGroups;
        private readonly IGenericRepository<ChatMessage> chatMessages;
        private readonly UserManager<Customer> userManager;
        private readonly IHubContext<ChatHub> hubContext;
        
        public NotificationController(IGenericRepository<Notification> notifications,
                                      IGenericRepository<NotificationUser> notificationUsers,
                                      IGenericRepository<ChatGroup> chatGroups,
                                      IGenericRepository<ChatMessage> chatMessages,
                                      UserManager<Customer> userManager,
                                      IHubContext<ChatHub> hubContext)
        {
            this.notifications = notifications;
            this.notificationUsers = notificationUsers;
            this.userManager = userManager;
            this.chatGroups = chatGroups;
            this.chatMessages = chatMessages;
            this.hubContext = hubContext;
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

        public async Task<IActionResult> GetChatNotification()
        {
            //any admin can answer
            ICollection<Customer> admins = await userManager.GetUsersInRoleAsync("Admin");
            List<string> adminGrouspIds = new List<string>();
            List<string> allAdminGroupIds = new List<string>();
            
            foreach (var admin in admins)
            {
                adminGrouspIds = chatGroups.FindAll(x => x.AdminId.Equals(admin.Id))
                    .Where(x=>!x.IsReadAdmin)
                    .Select(x=>x.ChatGroupId).ToList()
                    .ConvertAll(x => x.ToString());

                allAdminGroupIds.Concat(adminGrouspIds);
            }

            adminGrouspIds = adminGrouspIds.Distinct().ToList();

            return Ok(new { ChatGroups = adminGrouspIds });
        }

        public async Task<IActionResult> ReadChatNotification(long groupId)
        {
            ChatGroup chatGroup = chatGroups.Find(x => x.ChatGroupId.Equals(groupId));
            var lastMessages = chatMessages.GetAll();

            var messagesInGroup = lastMessages.Where(x => x.ChatGroupId.Equals(groupId)).ToList();

            var lastMessage = messagesInGroup.OrderByDescending(x => x.ChatMessageId).First();

            var admins = await userManager.GetUsersInRoleAsync("Admin");
            var adminIds = admins.Select(x => x.Id);
            
            if(adminIds.Contains(lastMessage.CustomerId))
            {
                chatGroup.IsReadAdmin = true;            
                chatGroups.Update(chatGroup);
            }

            return Ok();
        }

    }
}