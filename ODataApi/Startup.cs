using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Shared;
using Shared.Entities;

namespace ODataApi
{
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
            services.AddMvc(options =>
            {
                // TODO: Remove when OData does not causes exceptions anymore
                // See https://github.com/OData/WebApi/issues/1707
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddOData();

            SetupEFCore(services);

            services.AddScoped<BlogService>();
        }

        private void SetupEFCore(IServiceCollection services)
        {
            services.AddDbContext<SharedDbContext>(opt => opt.UseInMemoryDatabase("BlogService"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(b =>
            {
                // Enables all OData query options
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();

                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Author>("Authors");
            builder.EntitySet<Post>("Posts");
            builder.EntitySet<SocialNetworkProfile>("SocialNetworkProfiles");
            return builder.GetEdmModel();
        }
    }
}
