using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptionless;
using Exceptionless.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APM.Exce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessController : ControllerBase
    {
        [HttpGet]
        public void less()
        {
            ExceptionlessClient.Default.CreateLog("LessController", "Getting results", LogLevel.Info).Submit();
            throw new Exception($"Random AspNetCore Exception: {Guid.NewGuid()}");
        }
    }
}