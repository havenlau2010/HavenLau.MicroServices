using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
namespace MQ.Client.Messages
{
    [Queue("mq.client", ExchangeName = "mq.update.client")]
    public class UpdateMessage : MessageBase
    {
        private string _message = "";
        public string Text { get; set; }

        public string Identity { get; } = "MQ.UPDATE1.CLIENT";

        public string Message { get => PrintMessage(); }


        private string PrintMessage()
        {
            return $"ClientId:0002,ClientName:ClientName0002,Identity:{Identity},Text:{Text}";
        }
    }
}
