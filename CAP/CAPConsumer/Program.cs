using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace CAPConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //在MQ上定义一个队列，如果名称相同不会重复创建
                channel.QueueDeclare("sample.rabbitmq.sqlserver", false, false, false, null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                };
                channel.BasicConsume(queue: "sample.rabbitmq.sqlserver", autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
