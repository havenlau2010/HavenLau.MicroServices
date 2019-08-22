using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MQ.Client.SignalRHub;
using MQ.Models;

namespace MQ.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IHubContext<MQHub> _mqConext;
        public ValuesController(IHubContext<MQHub> mqConext)
        {
            _mqConext = mqConext;
        }

        // GET api/values/5
        [HttpGet()]
        public ActionResult<string> GetAsync(string str1, string str2)
        {
            _mqConext.Clients.All.SendAsync(MessageQueueEndpoints.FirstClientQueue, $"{str1},{str2}");
            return $"{str1},{str2}";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
