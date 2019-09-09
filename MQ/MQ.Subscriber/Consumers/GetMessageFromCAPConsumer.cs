using EasyNetQ.AutoSubscribe;
using MQ.Client.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MQ.Subscriber.Consumers
{
    public class GetMessageFromCAPConsumer : IConsumeAsync<string>
    {
        [AutoSubscriberConsumer(SubscriptionId = "mq.client")]
        public Task ConsumeAsync(string message)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("Consume one message from CAP : calling update apis");
            System.Console.WriteLine("Consume one message from CAP : {0}", message);
            System.Console.WriteLine("Consume one message from CAP : input your update business please!");
            System.Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
