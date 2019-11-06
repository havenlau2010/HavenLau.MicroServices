using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _context;
        public ChatHub(IHttpContextAccessor context)
        {
            _context = context;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string user,string message) 
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // public async Task Send
    }
}
