using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    public class FilterData
    {
        public string Name { get; set; }
        public bool?[] Gender { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private List<User> lstUser = new List<User>
        {
            new User{ Id = 1, Name = "A",Nick ="A",Gender=true },
            new User{ Id = 2, Name = "B",Nick ="B" ,Gender=false},
            new User{ Id = 3, Name = "BB",Nick ="B2" ,Gender=false},
            new User{ Id = 4, Name = "D",Nick ="D" ,Gender=true},
            new User{ Id = 11, Name = "11",Nick ="11",Gender=true },
        };

        [HttpGet("get1")]
        public List<User> Get(string filter)
        {
            IEnumerable<User> result = lstUser;
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    result = lstUser.Where(x => x.Name.Contains(filter));
                }
                /*
                if (filter.Gender != null)
                {
                    result = lstUser.Where(x => filter.Gender.ToList().Contains(x.Gender));
                }
                */
            }
            return result.ToList();
        }

        [HttpGet("get2")]
        public List<User> Get2([FromQuery] FilterData filter)
        {
            IEnumerable<User> result = lstUser;
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    result = lstUser.Where(x => x.Name.Contains(filter.Name));
                }
                /*
                if (filter.Gender != null)
                {
                    result = lstUser.Where(x => filter.Gender.ToList().Contains(x.Gender));
                }
                */
            }
            return result.ToList();
        }

        [HttpGet("get3")]
        public List<User> Get3([FromQuery] FilterData filter)
        {
            IEnumerable<User> result = lstUser;
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Name))
                {
                    result = lstUser.Where(x => x.Name.Contains(filter.Name));
                }
                
                if (filter.Gender != null)
                {
                    result = lstUser.Where(x => filter.Gender.ToList().Contains(x.Gender));
                }
            }
            return result.ToList();
        }
    }
}