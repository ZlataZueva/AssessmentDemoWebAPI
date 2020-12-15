using AssessmentDemo.Foundation.Interfaces;
using AssessmentDemo.Foundation.Services;
using AssessmentDemoWebAPI.Filters;
using AssessmentDemoWebAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AssessmentDemoWebAPI
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
            services.AddControllers();
            services.AddSingleton<IAmUseless, AmUseless>();
            services.AddScoped<IGiftsService, GiftsService>();
            services.AddScoped<LoggingMiddleware>();
            services.AddScoped<PriceFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint is null)
                {
                    return;
                }

                logger.LogInformation($"Endpoint: {endpoint.DisplayName}");

                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    logger.LogInformation("Endpoint has route pattern: " +
                                      routeEndpoint.RoutePattern.RawText);
                }

                foreach (var metadata in endpoint.Metadata)
                {
                    logger.LogInformation($"Endpoint has metadata: {metadata}");
                }

                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}