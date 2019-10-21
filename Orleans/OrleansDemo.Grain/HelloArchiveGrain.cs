using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Orleans;
using OrleansDemo.IGrain;

namespace OrleansDemo.Grain
{
    class HelloArchiveGrain : Grain<GreetingArchive>, IHelloArchive
    {
        public HelloArchiveGrain()
        {
        }

        public Task<IEnumerable<string>> GetGreetings()
        {
            return Task.FromResult<IEnumerable<string>>(State.Greetings);
        }

        public async Task<string> SayHello(string greeting)
        {
            State.Greetings.Add(greeting);
            await WriteStateAsync();
            return $"You said: '{greeting}', I say: Hello!";
        }
    }

    /// <summary>
    /// 数据流
    /// </summary>
    public class GreetingArchive 
    {
        public List<string> Greetings { get; } = new List<string>() { "default greeting..." };
    }
}
