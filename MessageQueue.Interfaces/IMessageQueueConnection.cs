using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQ.Interfaces
{
	public interface IMessageQueueConnection
	{
		void CreateConnection();
		IConnection GetConnection();
	}

}
