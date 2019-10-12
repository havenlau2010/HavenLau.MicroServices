using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exceptionless;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
namespace APM.CoreWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessController : ControllerBase
    {
        public void less()
        {
            // ExceptionlessClient.Default.CreateLog("LessController", "Getting results", LogLevel.Info).Submit();
            // throw new Exception($"Random AspNetCore Exception: {Guid.NewGuid()}");
            Log.ForContext<LessController>().Information("LessController information....");
        }
    }
}