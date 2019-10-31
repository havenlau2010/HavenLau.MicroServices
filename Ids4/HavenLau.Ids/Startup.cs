using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HavenLau.Ids.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using IdentityServer4.Quickstart.UI;
using System.IO;
using System.Reflection;
using HavenLau.Ids.Models;
using HavenLau.Ids.Data;

namespace HavenLau.Ids
{
    public class Startup
    {
        public Startup(IConfiguration configuration,IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            //services.AddControllersWithViews();
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            /*
            .AddTestUsers(InMemoryConfig.Users().ToList())
            .AddInMemoryApiResources(InMemoryConfig.GetApiResources().ToList())
            .AddInMemoryClients(InMemoryConfig.GetClients().ToList())
            */
            .AddAspNetIdentity<ApplicationUser>()
            .AddConfigurationStore(options=> {
                options.ConfigureDbContext = b =>
                b.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly));
            })
            .AddOperationalStore(options=> {
                options.ConfigureDbContext = b =>
                            b.UseSqlServer(connectionString,
                                sql => sql.MigrationsAssembly(migrationsAssembly));
                // 自动清理 token ，可选
                options.EnableTokenCleanup = true;
            });
            builder.AddDeveloperSigningCredential();
            services.AddAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            // app.UseAuthorization();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
