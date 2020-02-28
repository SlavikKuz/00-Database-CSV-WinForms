using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TubeStore.Models;
using TubeStore.DataLayer;

namespace TubeStore.Hubs
{
    public class ChatHub : Hub
    {
        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendToGroup(ChatMessage message)
        {
            string groupName = message.ChatGroupId.ToString();
            await Clients.Group(groupName).SendAsync("receiveMessage", message);
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
