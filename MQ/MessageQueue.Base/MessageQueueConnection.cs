using MQ.Interfaces;
using MQ.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQ.Base
{
    public class MessageQueueConnection  : IMessageQueueConnection
    {
	
		private ConnectionFactory _connectionFactory;
		private MessageQueueAppConfig _messageQueueAppConfig;
		private IConnection _connection;

		public MessageQueueConnection(MessageQueueAppConfig messageQueueAppConfig)
		{
			_messageQueueAppConfig = messageQueueAppConfig;
		}

		/// <summary>
		/// Create RabbitMQ Connection
		/// </summary>
		public void CreateConnection()
		{
			_connectionFactory = new ConnectionFactory();

			_connectionFactory.HostName = _messageQueueAppConfig.MessageQueueHostName;
			_connectionFactory.UserName = _messageQueueAppConfig.MessageQueueUserName;
			_connectionFactory.Password = _messageQueueAppConfig.MessageQueuePassword;

			_connection = _connectionFactory.CreateConnection();

		}

		public IConnection GetConnection()
		{
			return _connection;
		}

    }
}
