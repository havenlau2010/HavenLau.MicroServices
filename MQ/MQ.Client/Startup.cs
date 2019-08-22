using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MQ.Client.SignalRHub;
using AutoMapper;
namespace MQ.Client
{
    public struct StrClassStruct
    {
        public int Id { get; set; }

        public int Number { get; set; }
    }
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<DemoClass, DemoClassStruct>();
            CreateMap<StrClass, StrClassStruct>();

            
        }
    }

    public class DemoClass
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Message { get; set; }

        public List<StrClass> Flags { get; set; }
    }

    public class StrClass
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            return $"Id:{Id},Number:{Number}";
        }
    }

    public struct DemoClassStruct
    {
        public int Id { get; set; }

        public string Number { get; set; }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Models.MessageQueueAppConfig>(Configuration.GetSection("MQAppConfig"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(typeof(AutoMapProfile));
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSignalR(routes =>
            {
                routes.MapHub<MQHub>("/mqhub");
            });
        }
    }
}
