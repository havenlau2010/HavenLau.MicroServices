using DotNetCore.CAP;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAPConsoleDemo
{
    public class Publish : IHostedService
    {
        private readonly ICapPublisher _publisher;
        private Timer _timer;
        public const string QUEUE_NAME= "mq.client";
        public Publish(ICapPublisher publisher)
        {
            _publisher = publisher;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Work, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }
        private void Work(object state) {
            _publisher.Publish<string>(QUEUE_NAME, DateTime.Now.ToString());
            Console.WriteLine("推送MESSAGE FROM CAP：" + DateTime.Now.ToString());
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
