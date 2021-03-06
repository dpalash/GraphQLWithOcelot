using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotApiGateway.IoC;
using StartupBase = Framework.Core.Base.Api.StartupBase;

namespace OcelotApiGateway
{
    public class Startup : StartupBase
    {
        public Startup(IConfiguration configuration) : base(configuration, new UnityDependencyProvider(), "Ocelot Api Gateway")
        {

        }

        public override void ConfigureServices(IServiceCollection services)
        {
            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policyBuilder =>
                    {
                        // Not a permanent solution, but just trying to isolate the problem
                        policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddOcelot(Configuration)
                .AddCacheManager(x =>
                {
                    x.WithDictionaryHandle();
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Use the CORS policy
            app.UseCors("AllowAll");

            base.Configure(app, env);

            app.UseOcelot().Wait();
        }
    }
}
