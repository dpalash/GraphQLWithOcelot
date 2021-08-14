using System;
using GraphiQl;
using GraphQL.Core.DTOs;
using GraphQL.Core.InputType;
using GraphQL.Core.Interfaces.Repositories;
using GraphQL.Core.Interfaces.Services;
using GraphQL.Core.Models;
using GraphQL.Core.Services;
using GraphQL.Core.Types;
using GraphQL.MicroService.IoC;
using GraphQL.Repository.Repositories;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StartupBase = Framework.Core.Base.Api.StartupBase;

namespace GraphQL.MicroService
{
    public class Startup : StartupBase
    {
        private static string ApiTitle => "GraphQl Web Api";

        public Startup(IConfiguration configuration) : base(configuration, new UnityDependencyProvider(), ApiTitle)
        {

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = ApiTitle,
                    Version = "v1",
                    Description = $"Api list for {ApiTitle}"
                });
            });

            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ISchema, GraphQLDemoSchema>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<AuthorType>();
            services.AddTransient<AuthorInputType>();
            services.AddTransient<ProMutation>();
            services.AddTransient<BlogPostType>();

            services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(GraphQLDemoSchema), ServiceLifetime.Scoped);

            services.AddControllers()
                 .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("../swagger/v1/swagger.json", $"{ApiTitle} - Services"));

            app.UseGraphQL<GraphQLDemoSchema>();

            if (env.IsDevelopment())
            {
                app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()
                {
                    GraphQLEndPoint = "/api/graphQl/graph",
                    Path = "/api/graphQl/playground"
                });
            }
        }
    }
}
