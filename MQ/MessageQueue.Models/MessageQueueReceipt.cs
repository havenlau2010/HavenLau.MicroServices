using System;
using System.Collections.Generic;
using System.Text;

namespace MQ.Models
{
    public class MessageQueueReceipt
    {
		public string TransactionCode { get; set; }
		public int TransactionQueueId { get; set; }
		public int MessageQueueDirection { get; set; }
		public string Payload { get; set; }
	}
}
