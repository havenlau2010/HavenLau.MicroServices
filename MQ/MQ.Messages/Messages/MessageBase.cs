using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
namespace MQ.Client.Messages
{
    [Queue("mq.client", ExchangeName = "mq.client")]
    public abstract class MessageBase
    {
        public string ClientId { get; set; }

        public string ClientName { get; set; }
    }
}
