using DotNetCore.CAP;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Savorboard.CAP.InMemoryMessageQueue;
using System;

namespace CAPConsoleSubscribeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = new HostBuilder();
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppDbContext>();

                services.AddCap(x =>
                {
                    x.UseEntityFramework<AppDbContext>();
                    x.UseRabbitMQ("localhost");
                    x.UseDashboard();
                    x.FailedRetryCount = 5;
                    x.FailedThresholdCallback = (type, name, content) =>
                    {
                        Console.WriteLine($@"A message of type {type} failed after executing {x.FailedRetryCount} several times, requiring manual troubleshooting. Message name: {name}, message body: {content}");
                    };
                });
                
                services.AddHostedService<Subscribe>();
                services.AddSingleton<ICapSubscribe, Subscribe>();
            });
            return builder;
        }
    }
}
