using System;
using System.Threading.Tasks;
using Orleans;
namespace OrleansDemo.IGrain
{
    public interface IHello :IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }
}
