using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HavenLau.Consul.Client.Model
{
    public class ConsulOption
    {
        /// <summary>
        /// Consul主机
        /// </summary>
        public string ConsulHost { get; set; } 
        /// <summary>
        /// 当前服务名称
        /// </summary>
        public string ServiceName { get; set; } = "HavenLau.Consul.Client";
        /// <summary>
        /// 当前服务注册到Consul Tag
        /// </summary>
        //public List<string> ServiceTags { get; set; }
        /// <summary>
        /// 当前服务配置IP
        /// </summary>
        public string ServiceIP { get; set; }
        /// <summary>
        /// 当前服务配置端口
        /// </summary>
        public int ServicePort { get; set; }
        /// <summary>
        /// 当前服务检查点
        /// </summary>
        //public List<CheckItem> Checks { get; set; }
        /// <summary>
        /// 当前服务注册到Consul 前缀
        /// </summary>
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
