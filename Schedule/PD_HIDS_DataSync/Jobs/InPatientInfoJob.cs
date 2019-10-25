using FluentScheduler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PD_HIDS_DataSync.Jobs
{
    public class InPatientInfoJob : IJob
    {
        public static IServiceCollection Services;
        public InPatientInfoJob()
        // public InPatientInfoJob()
        {
            // _service = service;
        }

        public void Execute() 
        {
            using (var scope = Services.BuildServiceProvider().CreateScope())
            {
                using (var service = scope.ServiceProvider.GetRequiredService<IInPatientInfoJobService>())
                {
                    service.ExecuteJob();
                }
            }
            Console.WriteLine("InPatientInfoJob xxx ");
        }
    }
}
