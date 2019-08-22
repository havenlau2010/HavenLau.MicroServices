using System;
using System.Collections.Generic;
using System.Text;

namespace MQ.Models
{
    public class MessageQueue
    {
		public string TransactionCode { get; set; }
		public int TransactionQueueId { get; set; }
		public string Payload { get; set; }
		public string ExchangeName { get; set; }
		public string QueueName { get; set; }
		public Guid MessageGuid { get; set; }
	}
}
