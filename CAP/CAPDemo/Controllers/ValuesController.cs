using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace CAPDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICapPublisher _capBus;
        public ValuesController(ICapPublisher capPublisher)
        {
            _capBus = capPublisher;
        }
        [HttpGet("create")]
        public async Task<string> Get()
        {
            await _capBus.PublishAsync<string>("cap.queue.capdemo.v1", "hello，订单创建成功啦");  //发布Order.Created事件
            return "订单创建成功啦";
        }


        [NonAction]
        [CapSubscribe("Order.Created")]    //监听Order.Created事件
        public async Task OrderCreatedEventHand(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
