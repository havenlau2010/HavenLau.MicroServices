using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Orleans;
namespace OrleansDemo.IGrain
{
    public interface IHelloArchive : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);

        Task<IEnumerable<string>> GetGreetings();
    }
}
