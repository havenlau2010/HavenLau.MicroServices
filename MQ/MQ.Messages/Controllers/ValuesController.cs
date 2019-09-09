using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using MQ.Client.Messages;

namespace MQ.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IBus _bus;
        public ValuesController(IBus bus)
        {
            _bus = bus;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            await _bus.PublishAsync(new CreateMessage { Text = "value1+value2" });
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _bus.PublishAsync(new CreateMessage { Text = value });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _bus.PublishAsync(new UpdateMessage { Text = value });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bus.PublishAsync(new DeleteMessage { Text = id.ToString() });
        }
    }
}
