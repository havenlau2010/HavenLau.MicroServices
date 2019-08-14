using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HavenLau.Consul.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// 设置NetCore监听端口取命令行中的参数
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder()
             .AddCommandLine(args)
             .Build();


            try
            {
                Model.ConsulOption option = new Model.ConsulOption()
                {
                    ServiceIP = config["ServiceIP"],
                    ServicePort = Convert.ToInt32(config["ServicePort"]),
                    ConsulHost = config["ConsulHost"],
                    ServiceName = config["ServiceName"],
                    UrlPrefix = config["UrlPrefix"]
                };

                Console.WriteLine($"ip={option.ServiceIP},port={option.ServicePort}");
                return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls($"http://{option.ServiceIP}:{option.ServicePort}")
                .Build();
            }
            catch (Exception)
            {
                throw new Exception("Server Configuration Parameters can not be null...");
            }

            /*
            Model.ConsulOption option = config.Get<Model.ConsulOption>();
            if (option == null)
            {
                throw new Exception("Server Configuration Parameters can not be null...");
            }
            */
            
        }
    }
}
