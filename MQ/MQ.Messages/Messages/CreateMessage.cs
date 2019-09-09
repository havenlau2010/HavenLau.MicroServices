using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
namespace MQ.Client.Messages
{
    [Queue("mq.client", ExchangeName = "mq.create.client")]
    public class CreateMessage : MessageBase
    {
        private string _message = "";
        public string Text { get; set; }

        public string Identity { get; } = "MQ.CREATE1.CLIENT";
        public string Message { get => PrintMessage(); }


        private string PrintMessage()
        {
            return $"ClientId:0001,ClientName:ClientName0001,Identity:{Identity},Text:{Text}";
        }
    }
}
