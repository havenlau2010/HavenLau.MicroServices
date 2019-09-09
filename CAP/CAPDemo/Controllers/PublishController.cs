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
    public class PublishController : ControllerBase
    {
        [Route("~/send")]
        public IActionResult SendMessage([FromServices]ICapPublisher capBus)
        {
            capBus.Publish("test.show.time", DateTime.Now);

            return Ok();
        }
    }
}
