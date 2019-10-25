using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PD_HIDS_DataSync.Jobs;
using System;

namespace PD_HIDS_DataSync
{
    public static class JobExtension
    {
        public static void AddJobService(this IServiceCollection services)
        {
            services.AddScoped<IInPatientInfoJobService, InPatientInfoJobService>();
        }
    }
    class Program
    {
        private static int GetConfigInterval()
        {
            return 5;
        }

        private static void ExecuteJob()
        {
            JobManager.AddJob<InPatientInfoJob>((s) => s.ToRunEvery(GetConfigInterval()).Seconds());
        }

        static void Main(string[] args)
        {
            var host = new HostBuilder();
            host.ConfigureAppConfiguration((builder) =>
            {

            })
            .ConfigureServices((context, services) =>
            {
                services.AddJobService();
                InPatientInfoJob.Services = services;
                ExecuteJob();
            }).Build().Run();

           
            Console.ReadKey();
        }
    }
}
