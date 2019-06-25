using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLApi.GraphQl;
using GraphQLApi.GraphQl.Types.Inputs;
using GraphQLApi.GraphQl.Types.Outputs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace GraphQLApi
{
    public class Startup
    {
        public const string GraphQlPath = "/graphql";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            SetupEFCore(services);
            SetupSharedDependencies(services);
            SetupGraphQl(services);
        }

        private static void SetupEFCore(IServiceCollection services)
        {
            services.AddDbContext<SharedDbContext>(opt => opt.UseInMemoryDatabase("BlogService"));
        }

        private static void SetupSharedDependencies(IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogService>();
        }

        private static void SetupGraphQl(IServiceCollection services)
        {
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<AuthorType>();
            services.AddScoped<AuthorInputType>();
            services.AddScoped<CommentType>();
            services.AddScoped<PostType>();
            services.AddScoped<SocialNetworkProfileType>();
            services.AddScoped<SocialNetworkTypeType>();
            services.AddScoped<BlogServiceQuery>();
            services.AddScoped<BlogServiceMutation>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<ISchema, BlogServiceSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl(GraphQlPath);
            app.UseMvc();
        }
    }
}
