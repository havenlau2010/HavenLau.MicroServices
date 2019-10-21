using Microsoft.Extensions.Logging;
using OrleansDemo.IGrain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrleansDemo.Grain
{
    public class HelloGrain : Orleans.Grain, IHello
    {
        private readonly ILogger _logger;
        public HelloGrain(ILogger<HelloGrain> logger)
        {
            _logger = logger;
        }
        public Task<string> SayHello(string greeting)
        {
            _logger.LogInformation($"SayHello message received: greeting = '{greeting}'");
            return Task.FromResult($"SayHello=====>>>>>You said: '{greeting}', I say: Hello!");
        }

        Task<string> IHello.SayHello(string greeting)
        {
            _logger.LogInformation($"SayHello message received: greeting = '{greeting}'");
            return Task.FromResult($"IHello.SayHello=====>>>>>You said: '{greeting}', I say: Hello!");
        }
    }
}
