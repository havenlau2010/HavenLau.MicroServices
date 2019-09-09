using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CAPConsoleSubscribeDemo
{
    public class Subscribe : ICapSubscribe
    {
        public const string QUEUE_NAME = "cap.queue.capdemo.v1";

        [CapSubscribe(QUEUE_NAME)]
        public async Task OrderCreatedEventHandler(string msg)
        {
            Console.WriteLine("GROUP-001--接收：" + msg);
        }


        [CapSubscribe(QUEUE_NAME)]
        public async Task OrderCreatedEventHandler2(string msg)
        {
            Console.WriteLine("GROUP-002--接收：" + msg);
        }
    }
}
