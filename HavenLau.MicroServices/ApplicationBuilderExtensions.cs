using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace HavenLau.Consul.Server
{
    public partial class ApiResourcesHelper
    {
        public string GetSectionString()
        {

            var types = ConsulGenerator.GetControllerClasses(typeof(Program).Assembly);

            ConsulGenerator generator = new ConsulGenerator();
            ConsulOption option = generator.GenerateForControllers(types);
            
            return JsonConvert.SerializeObject(option);
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddConsulData(this IApplicationBuilder app)
        {
            string resource = new ApiResourcesHelper().GetSectionString();

            System.Console.WriteLine(resource.ToString());
            return app;
        }
    }
}
