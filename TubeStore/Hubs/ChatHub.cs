using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;
using TubeStore.Models.Chat;
using TubeStore.DataLayer;
using Microsoft.AspNetCore.Identity;
using TubeStore.Models;
using System.Collections.Generic;
using System;

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
                    AdminId = admin.Id
                };
                await chatGroups.AddAsync(chatGroup);
            }

            long chatGroupId = (await chatGroups.FindAsync(x => x.CustomerId.Equals(customer.Id))
                ).ChatGroupId;

            ICollection<ChatMessage> lastMessages = await chatMessages.FindAllAsync(
                x => x.ChatGroupId.Equals(chatGroupId));

            lastMessages.OrderBy(x=>x.ChatMessageId);
            
            await Groups.AddToGroupAsync(Context.ConnectionId, chatGroupId.ToString());
            
            await Clients.Group(chatGroupId.ToString()).SendAsync("receiveMessages", lastMessages);
        }

        //public async Task RequestLastMessages()
        //{
        //    string userName = Context.User.Identity.Name;
        //    var customer = await userManager.FindByNameAsync(userName);
        //    chatGroup = await chatGroups.FindAsync(x => x.CustomerId.Equals(customer.Id));
        //    long chatGroupId = chatGroup.ChatGroupId;

        //    ICollection<ChatMessage> lastMessages = await chatMessages.FindAllAsync(
        //        x => x.ChatGroupId.Equals(chatGroupId));

        //    await Clients.Group(chatGroupId.ToString()).SendAsync("receiveMessage", lastMessages);
        //}
             
        public async Task SendToGroup(string text)
        {
            string userName = Context.User.Identity.Name;
            var customer = await userManager.FindByNameAsync(userName);
            chatGroup = await chatGroups.FindAsync(x => x.CustomerId.Equals(customer.Id));
            string chatGroupId = chatGroup.ChatGroupId.ToString();

            chatMessage = new ChatMessage
            {
                MessageText = text,
                ChatGroupId = chatGroup.ChatGroupId,
                CustomerId = customer.Id,
                UserName = customer.FirstName + " " + customer.LastName,
                MessageDate =  DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToShortDateString()
            };

            await chatMessages.AddAsync(chatMessage);

            await Clients.Group(chatGroupId).SendAsync("receiveMessage", chatMessage);
        }

        public override async Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            var customer = await userManager.FindByNameAsync(userName);

            chatGroup = await chatGroups.FindAsync(x => x.CustomerId.Equals(customer.Id));

            if(chatGroup!=null)
                await Groups.AddToGroupAsync(Context.ConnectionId, chatGroup.ChatGroupId.ToString());

            await base.OnConnectedAsync();
        }
    }
}
