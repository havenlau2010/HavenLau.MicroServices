using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentScheduler;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PD_HIDS_DataSync.Api.Jobs;

namespace PD_HIDS_DataSync.Api
{
    public static class JobExtension {
        public static void AddJobService(this IServiceCollection services) 
        {
            services.AddScoped<IInPatientInfoJobService,InPatientInfoJobService>();
        }
    }

    public class Program
    {
        private static int GetConfigInterval()
        {
            return 5;
        }

        private static void ExecuteJob()
        {
            JobManager.AddJob<InPatientInfoJob>((s) => s.ToRunEvery(GetConfigInterval()).Seconds());
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((builder,services)=> {
                    services.AddJobService();
                    InPatientInfoJob.Services = services;
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    ExecuteJob();
                });
    }
}
