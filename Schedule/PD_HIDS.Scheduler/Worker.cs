using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PD_HIDS.Scheduler.Service;
using PD_HIDS.Scheduler.IService;

namespace PD_HIDS.Scheduler
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public static IServiceCollection Services;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using (var scope = Services.BuildServiceProvider().CreateScope())
                {
                    using (var service = scope.ServiceProvider.GetRequiredService<IInPatientInfoJobService>())
                    {
                        service.ExecuteJob();
                    }
                }
            }
        }
    }
}
