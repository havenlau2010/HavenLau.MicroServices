using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HavenLau.Consul.Server.Controllers
{
    [Produces("application/json")]
    [Route("api/my")]
    public class MyController : Controller
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = false)]
        public IActionResult Get() => Ok("ok");

        [HttpGet(Name ="get2")]
        public IActionResult Get2() => Ok("ok2");
    }
}