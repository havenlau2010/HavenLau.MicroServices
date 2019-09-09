using EasyNetQ.AutoSubscribe;
using MQ.Client.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQ.Subscriber.Consumers
{
    public class UpdateMessageConsumer : IConsumeAsync<UpdateMessage>
    {
        [AutoSubscriberConsumer(SubscriptionId = "MQ.Subscriber.NO2")]
        public Task ConsumeAsync(UpdateMessage message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("Consume one message from RabbitMQ : calling update apis");
            System.Console.WriteLine("Consume one message from RabbitMQ : {0}", message.ClientName);
            System.Console.WriteLine("Consume one message from RabbitMQ : {0}", message.Message);
            System.Console.WriteLine("Consume one message from RabbitMQ : input your update business please!");
            System.Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
