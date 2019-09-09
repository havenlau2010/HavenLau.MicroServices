using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Savorboard.CAP.InMemoryMessageQueue;

namespace CAPConsoleDemo
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
                services.AddCap(x =>
                {
                    x.UseInMemoryStorage();
                    x.UseInMemoryMessageQueue();
                    x.UseDashboard();
                });
                services.AddHostedService<Publish>();
            });
            return builder;
        }
    }
}
