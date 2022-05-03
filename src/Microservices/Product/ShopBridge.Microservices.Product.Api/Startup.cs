using AutoWrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace ShopBridge.Microservices.Product.Api
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

            services.AddCustomMvc()
                .AddCustomSwagger()
                .AddCustomAutoMapper()
                .AddCustomAutoWrapper()
                .AddCustomDatabase(Configuration)
                .AddCustomAssemblies()
                .AddCustomHealthChecks(Configuration)
                .AddCustomAuthentication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();

            var pathBase = Configuration.GetValue<string>("PathBase");
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(options =>
                {
                    options.RouteTemplate = $"{(!string.IsNullOrEmpty(pathBase) ? pathBase + "/" : string.Empty)}{options.RouteTemplate}";
                    options.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                    {
                        swaggerDoc.Servers = new List<OpenApiServer>
                        {
                            new OpenApiServer
                            {
                                Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{(!string.IsNullOrEmpty(pathBase) ? "/" + pathBase : string.Empty)}"
                            }
                        };
                    });
                });
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? "/" + pathBase : string.Empty) }/swagger/v1/swagger.json", "Product API v1");
                    c.RoutePrefix = $"{ (!string.IsNullOrEmpty(pathBase) ? pathBase + "/" : string.Empty) }{c.RoutePrefix}";
                });
            }

            if (!string.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase("/" + pathBase);
            }

            app.UseApiResponseAndExceptionWrapper(options: new AutoWrapperOptions() { UseCamelCaseNamingStrategy = false });
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
