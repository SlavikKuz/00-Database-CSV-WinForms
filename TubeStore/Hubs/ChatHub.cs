using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TubeStore.Models;
using TubeStore.Models.Chat;
using TubeStore.DataLayer;
using Microsoft.AspNetCore.Http;

namespace TubeStore.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IGenericRepository<ChatGroup> chatGroups;

        public ChatHub(IGenericRepository<ChatGroup> chatGroups)
        {
            this.chatGroups = chatGroups;
        }

        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendToGroup(ChatMessage message)
        {
            string groupName = message.ChatGroupId.ToString();
            await Clients.Group(groupName).SendAsync("receiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            string userName = Context.User.Identity.Name;
            string group = chatGroups.FindAll(x => x.ChatGroupName == userName).Select(x=>x.ChatGroupId).First().ToString();
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await base.OnConnectedAsync();
        }
    }
}
