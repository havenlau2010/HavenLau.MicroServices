using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQ.Client.SignalRHub
{
    public class MQHub : Hub
    {
        public MQHub()
        {
        }

        public override Task OnConnectedAsync()
        {
            string userId = Context.User.Claims.Where(m => m.Type == "id").ToString();
            return base.OnConnectedAsync();
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
