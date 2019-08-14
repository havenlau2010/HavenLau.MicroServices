using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavenLau.Consul.Server
{
    public class ConsulOption
    {
        public string ConsulHost { get; set; }
        public string ServiceName { get; set; }
        public List<string> ServiceTags { get; set; }
        public string ServiceIP { get; set; }
        public int ServicePort { get; set; }
        public List<CheckItem> Checks { get; set; }
        public string UrlPrefix { get; set; } = "urlprefix-/";
        public class CheckItem
        {
            public string Url { get; set; }
            public int Interval { get; set; } = 10;
            public int Timeout { get; set; } = 20;
            public int Deregister { get; set; } = 5;
        }
    }
}
