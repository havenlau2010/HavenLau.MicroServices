using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PD_HIDS.Scheduler.IService;
using PD_HIDS.Scheduler.Service;

namespace PD_HIDS.Scheduler
{
    public static class JobExtension
    {
        public static void AddJobService(this IServiceCollection services)
        {
            services.AddScoped<IInPatientInfoJobService, InPatientInfoJobService>();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configuration=> { 
                    
                })
                .ConfigureAppConfiguration((context,configuration)=> { 
                                        
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddJobService();
                    Worker.Services = services;
                    services.AddHostedService<Worker>();
                });
    }
}
