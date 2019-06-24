using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ODataApi.Versioning;
using Shared;
using Swashbuckle.AspNetCore.SwaggerGen;

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

            var defaultApiVersion = new ApiVersion(1, 0);

            services.AddApiVersioning(v =>
            {
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.DefaultApiVersion = defaultApiVersion;
                v.ReportApiVersions = true;
            });

            services
                .AddOData()
                .EnableApiVersioning();

            services.AddODataApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();
                });

            SetupEFCore(services);
            services.AddScoped<BlogService>();
        }

        private void SetupEFCore(IServiceCollection services)
        {
            services.AddDbContext<SharedDbContext>(opt => opt.UseInMemoryDatabase("BlogService"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            VersionedODataModelBuilder modelBuilder,
            IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(b =>
            {
                // Globally enabling all OData query options: 
                b.Select().Expand().Filter().OrderBy().MaxTop(100).Count();

                b.MapVersionedODataRoutes("odata", "odata/v{version:apiVersion}", modelBuilder.GetEdmModels());
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}
