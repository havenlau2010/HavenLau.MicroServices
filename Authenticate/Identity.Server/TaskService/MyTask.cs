using Identity.Server.Data;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Server.TaskService
{
    public class MyTask : BackgroundService
    {
        private readonly ApplicationDbContext _context;
        public MyTask(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // throw new NotImplementedException();
            if (!stoppingToken.IsCancellationRequested)
            {
                System.Console.Write(_context.ContextId);
                
            }
            return Task.CompletedTask;
        }
    }
}
