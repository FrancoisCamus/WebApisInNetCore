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

            SetupApiVersioning(services);
            services.AddVersionedApiExplorer(options => options.SubstituteApiVersionInUrl = true);

            SetupEFCore(services);
            SetupSwagger(services);

            services.AddScoped<IBlogService, BlogService>();
        }

        private void SetupApiVersioning(IServiceCollection services)
        {
            var defaultApiVersion = new ApiVersion(1, 0);

            services.AddApiVersioning(v =>
            {
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = defaultApiVersion;
            });
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
            app.UseSwaggerUi3();

            app.UseMvc();
        }
    }
}
