using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shared;

namespace ClassicRestApi
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
            services
                .AddMvc()
                .AddJsonOptions(options => {
                    // Avoiding self reference exception for Author property on Post
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            SetupEFCore(services);
            SetupSwagger(services);

            services.AddScoped<BlogService>();
        }

        private void SetupEFCore(IServiceCollection services)
        {
            services.AddDbContext<SharedDbContext>(opt => opt.UseInMemoryDatabase("BlogService"));
        }

        private static void SetupSwagger(IServiceCollection services)
        {
            services.AddSwaggerDocument(
                c =>
                {
                    c.PostProcess = document =>
                    {
                        document.Info.Title = "Blog Service";
                        document.Info.Version = "v1";
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(config =>
            {
                config.Path = "/api/swagger";
                config.TransformToExternalPath = (internalUiRoute, request) =>
                {
                    if (internalUiRoute.StartsWith("/") == true && internalUiRoute.StartsWith(request.PathBase) == false)
                    {
                        return request.PathBase + internalUiRoute;
                    }
                    else
                    {
                        return internalUiRoute;
                    }
                };
            });

            app.UseMvc();
        }
    }
}
