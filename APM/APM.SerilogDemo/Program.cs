using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace APM.SerilogDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                 .ConfigureLogging(x =>
                 {
                     x.SetMinimumLevel(LogLevel.Information);
                     x.AddConsole(x => x.TimestampFormat = "yyyy-MM-dd HH:mm:ss.SSS");
                     x.AddSerilog();
                 })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 })
                 .UseSerilog((ctx, logger) =>
                 {
                     logger
                     .MinimumLevel.Verbose()
                     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                     .MinimumLevel.Override("System", LogEventLevel.Warning)
                     .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
                     .MinimumLevel.Override("APM.SerilogDemo", LogEventLevel.Warning)
                     .Enrich.FromLogContext()
                     .WriteTo.File("systemlog.txt")
                     .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
                 });
        }
    }
}
