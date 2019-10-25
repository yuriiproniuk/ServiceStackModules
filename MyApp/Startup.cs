using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Funq;
using ServiceStack;
using MyApp.ServiceInterface;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyApp
{
    public class Startup : ModularStartup
    {
        public Startup(IConfiguration configuration) : base(configuration) {}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public new void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseServiceStack(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });
        }
    }

    public class AppHost : AppHostBase
    {
        //private static List<string> _assemblies = new List<string>();
#if CLIENT_A
        private static List<string> _assemblies = new List<string> { "MyApp.ServiceInterface", "MyApp.ServiceInterface.ClientA" };
#endif
#if CLIENT_B
        private static List<string> _assemblies = new List<string> { "MyApp.ServiceInterface", "MyApp.ServiceInterface.ClientB" };
#endif
#if DEBUG
        private static List<string> _assemblies = new List<string> { "MyApp.ServiceInterface", "MyApp.ServiceInterface.ClientA", "MyApp.ServiceInterface.ClientB" };
#endif
#if DEFAULT
        private static List<string> _assemblies = new List<string> { "MyApp.ServiceInterface" };
#endif
        private static List<string> Assemblies 
        {
            get { return _assemblies; }
            set { _assemblies = value; }
        } 

        public AppHost() : base("MyApp", Assemblies.Select(Assembly.Load).ToArray()) { }

        // Configure your AppHost with the necessary configuration and dependencies your App needs
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                DefaultRedirectPath = "/metadata",
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false)
            });
        }
    }
}
