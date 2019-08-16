using RabbitMQ.Client;
using System;
using System.Text;

namespace HavenLau.MQ.Sender
{
    class Program
    {
        static void SendMessage()
        {
            var factory = new ConnectionFactory() { HostName = "http://127.0.0.1" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("my quene", false, false, autoDelete: false, arguments: null);
                    string message = "message need to be sending...";
                    var messageBytes = Encoding.UTF8.GetBytes(message);
                    
                }
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
        }
    }
}
