using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
namespace MQ.Client.Messages
{
    [Queue("mq.client", ExchangeName = "mq.delete.client")]
    public class DeleteMessage : MessageBase
    {
        private string _message = "";
        public string Text { get; set; }

        public string Identity { get; } = "MQ.DELETE1.CLIENT";
        public string Message { get => PrintMessage(); }


        private string PrintMessage()
        {
            return $"ClientId:0003,ClientName:ClientName0003,Identity:{Identity},Text:{Text}";
        }
    }
}
