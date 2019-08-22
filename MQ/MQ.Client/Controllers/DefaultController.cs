using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MQ.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        private readonly IMapper _mapper;
        public DefaultController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("get1")]
        public ActionResult<string> GetAsync(string str1, string str2)
        {
            DemoClass c1 = new DemoClass
            {
                Id = 1,
                Number = "aaa",
                Message = "aaabbb",
                Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                }
            };
            DemoClass c2 = new DemoClass
            {
                Id = 1,
                Number = "aaa",
                Message = "aaabbb",
                Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                }
            };

            DemoClassStruct dcs1 = _mapper.Map<DemoClassStruct>(c1);
            DemoClassStruct dcs2 = _mapper.Map<DemoClassStruct>(c2);

            return $"c1.Equals(c2)=>{c1.Equals(c2)},dcs1.Equals(dcs2)=>{dcs1.Equals(dcs2)}";
        }


        [HttpGet("get2")]
        public ActionResult<string> Get2Async(string str1, string str2)
        {
            List<DemoClass> lst1 = new List<DemoClass>
            {
                new DemoClass { Id = 1, Number = "aaa", Message = "aaabbb" },
                new DemoClass { Id = 2, Number = "aaa", Message = "ccccc" }
            };

            List<DemoClass> lst2 = new List<DemoClass>
            {
                new DemoClass { Id = 1, Number = "aaa", Message = "aaabbb" },
                new DemoClass { Id = 2, Number = "aaa", Message = "ccccc" }
            };

            var result = from a in lst1
                         join b in lst2 on a.Id equals b.Id
                         where a.Message == b.Message
                         && a.Number == b.Number
                         select a;

            return $"lst11.Equals(lst22)=>{result.ToArray().Length == lst1.Count}";
        }


        [HttpGet("get3")]
        public ActionResult<string> Get3Async(string str1, string str2)
        {
            List<DemoClass> lst1 = new List<DemoClass>
            {
                new DemoClass { Id = 1, Number = "aaa", Message = "aaabbb", Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                } },
                new DemoClass { Id = 2, Number = "aaa", Message = "ccccc" , Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                }}
            };

            List<DemoClass> lst2 = new List<DemoClass>
            {
                new DemoClass { Id = 1, Number = "aaa", Message = "aaabbb", Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                } },
                new DemoClass { Id = 2, Number = "aaa", Message = "ccccc" , Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                }}
            };

            var result = from a in lst1
                         join b in lst2 on a.Id equals b.Id
                         where a.Message == b.Message
                         && a.Number == b.Number
                         && a.Flags.Select(p => p.ToString()) == b.Flags.Select(p => p.ToString())
                         select a;

            return $"lst11.Equals(lst22)=>{result.ToArray().Length == lst1.Count}";
        }



        [HttpGet("get4")]
        public ActionResult<string> Get4Async(string str1, string str2)
        {
            List<DemoClass> lst1 = new List<DemoClass>
            {
                new DemoClass { Id = 1, Number = "aaa", Message = "aaabbb", Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                } },
                new DemoClass { Id = 2, Number = "aaa", Message = "ccccc" , Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                }}
            };

            List<DemoClass> lst2 = new List<DemoClass>
            {
                new DemoClass { Id = 1, Number = "aaa", Message = "aaabbb", Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                } },
                new DemoClass { Id = 2, Number = "aaa", Message = "ccccc" , Flags = new List<StrClass> {
                    new StrClass { Id = 1, Number = 1 },
                    new StrClass { Id = 2, Number = 2 }
                }}
            };

            var sourceChildren = lst1.Select(p => p.Flags.Select(q => _mapper.Map<DemoClassStruct>(q)));
            var targetChildren = lst2.Select(p => p.Flags.Select(q => _mapper.Map<DemoClassStruct>(q)));

            DemoClass demoClass;
            foreach (var item in lst1)
            {
                demoClass = lst2.FirstOrDefault(p => p.Id == item.Id);
                if (demoClass == null)
                {
                    return $"has changed";
                }
                foreach (var flag in item.Flags)
                {
                    bool result = demoClass.Flags.Any(p => p.Id == flag.Id && p.Number == flag.Number);
                    if (!result)
                    {
                        return $"has changed";
                    }
                }
            }
            return $"lst11.Equals(lst22)=>{sourceChildren == targetChildren}";
        }
    }
}