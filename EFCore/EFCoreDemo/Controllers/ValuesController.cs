using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swifter.Json;
namespace EFCoreDemo.Controllers
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nick { get; set; }
    }


    public class FixedUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nick { get; set; }

        public string Fix { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<User> lstUser = new List<User>
        {
            new User{ Id = 1, Name = "A",Nick ="A" },
            new User{ Id = 2, Name = "B",Nick ="B" },
            new User{ Id = 11, Name = "11",Nick ="11" },
        };


        private List<FixedUser> lstFixedUser = new List<FixedUser>
        {
            new FixedUser{ Id = 1, Name = "A",Nick ="AA" },
            new FixedUser{ Id = 2, Name = "B",Nick ="B" },
            new FixedUser{ Id = 3, Name = "C",Nick ="BC" },
        };


        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            var joinResult = from a in lstUser
                             join b in lstFixedUser on a.Name equals b.Name
                             select b;

            var leftResult = from a in lstUser.Where(p => !joinResult.Select(x => x.Name).Contains(p.Name)) select a;

            var rightResult = lstFixedUser.Select(p => new User { Id = p.Id, Name = p.Name, Nick = p.Nick });

            var finalResult = leftResult.Union(rightResult).OrderBy(p => p.Name);

            string json = JsonFormatter.SerializeObject(finalResult);

            return json;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var lst  = lstUser.Where(x => x.Name == "AAAAA");
            if (lst.Count() == 0)
            {
                return "aaaaaa";
            }
            return lst.Max(x=>x.Id).ToString();
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
