using EasyNetQ.AutoSubscribe;
using MQ.Client.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQ.Subscriber.Consumers
{
    public class DeleteMessageConsumer : IConsumeAsync<DeleteMessage>
    {
        [AutoSubscriberConsumer(SubscriptionId = "MQ.Subscriber.NO3")]
        public Task ConsumeAsync(DeleteMessage message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("Consume one message from RabbitMQ : calling delete apis");
            System.Console.WriteLine("Consume one message from RabbitMQ : {0}", message.ClientName);
            System.Console.WriteLine("Consume one message from RabbitMQ : {0}", message.Message);
            System.Console.WriteLine("Consume one message from RabbitMQ : input your delete business please!");
            System.Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
