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
    public class ConsumerController : ControllerBase
    {
        [NonAction]
        [CapSubscribe("test.show.time")]
        public void ReceiveMessage(DateTime time)
        {
            Console.WriteLine("message time is:" + time);
        }
    }
}
