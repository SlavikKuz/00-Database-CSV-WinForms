using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models.Chat;
using TubeStore.DataLayer;
using Microsoft.AspNetCore.Identity;
using TubeStore.Models;
using System.Collections.Generic;
using System;
using System.Security.Principal;
using System.Text.Json;

namespace TubeStore.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IGenericRepository<ChatGroup> chatGroups;
        private readonly IGenericRepository<ChatMessage> chatMessages;
        private readonly UserManager<Customer> userManager;
        private ChatGroup chatGroup;
        private ChatMessage chatMessage;

        public ChatHub(IGenericRepository<ChatGroup> chatGroups,
                       IGenericRepository<ChatMessage> chatMessages,
                       UserManager<Customer> userManager)
        {
            this.chatGroups = chatGroups;
            this.chatMessages = chatMessages;
            this.userManager = userManager;
        }

        public async Task JoinGroup()
        {
            string userName = Context.User.Identity.Name;
            var customer = await userManager.FindByNameAsync(userName);
            var admin = (await userManager.GetUsersInRoleAsync("Admin")).FirstOrDefault();

            if (!chatGroups.Exist(x => x.CustomerId.Equals(customer.Id)))
            {
                chatGroup = new ChatGroup
                {
                    CustomerId = customer.Id,
                    AdminId = admin.Id,
                    IsReadAdmin = false
                };
                await chatGroups.AddAsync(chatGroup);
            }

            long chatGroupId = (await chatGroups.FindAsync(x => x.CustomerId.Equals(customer.Id))
                ).ChatGroupId;

            ICollection<ChatMessage> lastMessages = await chatMessages.FindAllAsync(
                x => x.ChatGroupId.Equals(chatGroupId));

            lastMessages.OrderBy(x => x.ChatMessageId);

            await Groups.AddToGroupAsync(Context.ConnectionId, chatGroupId.ToString());

            await Clients.Group(chatGroupId.ToString()).SendAsync("receiveMessages", lastMessages);
        }

        public async Task SendToGroup(string text)
        {
            string userName = Context.User.Identity.Name;
            var customer = await userManager.FindByNameAsync(userName);
            chatGroup = await chatGroups.FindAsync(x => x.CustomerId.Equals(customer.Id));

            chatGroup.IsReadAdmin = false;
            await chatGroups.UpdateAsync(chatGroup);

            string chatGroupId = chatGroup.ChatGroupId.ToString();

            chatMessage = new ChatMessage
            {
                MessageText = text,
                ChatGroupId = chatGroup.ChatGroupId,
                CustomerId = customer.Id,
                UserName = customer.FirstName + " " + customer.LastName,
                MessageDate = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString()
            };

            await chatMessages.AddAsync(chatMessage);

            await Clients.Group(chatGroupId).SendAsync("receiveMessage", chatMessage);
        }

        public override async Task OnConnectedAsync()
        {
            var customer = await userManager.FindByNameAsync(Context.User.Identity.Name);
            var admins = await userManager.GetUsersInRoleAsync("Admin");

            if (!admins.Contains(customer))
            {
                chatGroup = await chatGroups.FindAsync(x => x.CustomerId.Equals(customer.Id));

                if (chatGroup != null)
                    await Groups.AddToGroupAsync(Context.ConnectionId, chatGroup.ChatGroupId.ToString());
            }
            else
            {
                List<string> chatGroupsNotRead = chatGroups.FindAll(x => !x.IsReadAdmin)
                    .Select(x => x.ChatGroupId).ToList()
                    .ConvertAll(x => x.ToString());

                foreach (var groupId in chatGroupsNotRead)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
                }

            }
            await base.OnConnectedAsync();
        }

        public async Task GetChatMessagesAdmin(JsonElement groupId)
        {
            long longGroupId = (long)groupId.GetUInt64();

            ICollection<ChatMessage> lastMessages = await chatMessages.FindAllAsync(
                x => x.ChatGroupId.Equals(longGroupId));

            await Groups.AddToGroupAsync(Context.ConnectionId, longGroupId.ToString());

            await Clients.Group(longGroupId.ToString()).SendAsync("receiveAdminChatMessages", lastMessages);
        }

        public async Task SendAdminToGroup(string text, long groupAdminId)
        {
            string userName = Context.User.Identity.Name;
            var customer = await userManager.FindByNameAsync(userName);

            chatMessage = new ChatMessage
            {
                MessageText = text,
                ChatGroupId = groupAdminId,
                CustomerId = customer.Id,
                UserName = customer.FirstName + " " + customer.LastName,
                MessageDate = DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString()
            };

            await chatMessages.AddAsync(chatMessage);

            await Clients.Group(groupAdminId.ToString()).SendAsync("receiveChatMessage", chatMessage);
        }
    }
}
