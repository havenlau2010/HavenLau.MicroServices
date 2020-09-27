using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        private readonly List<DataList> datas;
        public LinqController()
        {
            datas = new List<DataList>
            {
                 new DataList { Id = 1, Name="L1"},
                 new DataList { Id = 2, Name="L2"},
                 new DataList { Id = 3, Name="L3"},
                 new DataList { Id = 4, Name="L4"},
                 new DataList { Id = 5, Name="L5"},
                 new DataList { Id = 6, Name="L6"},
                 new DataList { Id = 7, Name="L7"},
            };
        }


        [HttpPost("join")]
        public IActionResult Join([FromBody] List<RequestDataList> request)
        {
            // var joinResult = datas.Join(request, x => x.Id, y => y.RId, (x, y) => x);
            var joinResult = datas.Join(request, x => x.Id, y => y.RId, (x, y) =>
            {
                x.Name = x.Name + "-" + y.Name;
                return x;
            });
            return Ok(joinResult);
        }

        [HttpPost("except")]
        public IActionResult Except([FromBody] List<RequestDataList> request)


        {
            var requestList = request.Select(x => new DataList { Id = x.RId, Name = x.Name, Class = x.Class });
            var joinResult = datas.Except<DataList>(requestList, new DataListComparer());
            return Ok(joinResult);
        }

        [HttpPost("except2")]
        public IActionResult Except2([FromBody] List<RequestDataList> request)
        {
            var requestList = request.Select(x => new DataList { Id = x.RId, Name = x.Name, Class = x.Class });
            var joinResult = datas.Except<DataList>(requestList, new DataListComparer2());
            return Ok(joinResult);
        }


        [HttpPost("array-any")]
        public IActionResult AnyAsync([FromBody] int[] request)
        {
            return Ok(request.Any());
        }

        [HttpPost("list-any")]
        public IActionResult AnyAsync([FromBody] List<RequestDataList> request)
        {
            return Ok(request.Any());
        }
    }

    public class DataList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Class { get; set; } = "1";
    }


    public class RequestDataList
    {
        public int RId { get; set; }

        public string Name { get; set; }

        public string Class { get; set; } = "1";
    }

    public class DataListComparer : IEqualityComparer<DataList>
    {
        public bool Equals([AllowNull] DataList x, [AllowNull] DataList y)
        {
            return x != null && y != null && x.Id == y.Id;
        }


        public int GetHashCode([DisallowNull] DataList obj)
        {
            return obj.Id.GetHashCode();
        }
    }


    public class DataListComparer2 : IEqualityComparer<DataList>
    {
        public bool Equals([AllowNull] DataList x, [AllowNull] DataList y)
        {
            return x != null && y != null && x.Id == y.Id && x.Class == y.Class;
        }


        public int GetHashCode([DisallowNull] DataList obj)
        {
            return obj.Id.GetHashCode() ^ obj.Name.GetHashCode() ^ obj.Class.GetHashCode();
        }
    }
}
