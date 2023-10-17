using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace AllInOneForum.Utils
    {
    public static class Startup
    {
        public static IServiceCollection RegisterAutoMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.Load("AllInOneForum.Utils"));
            return services;
        }

        public static void RegisterSerilog(this WebApplicationBuilder? builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();
            try
            {
                Log.Information("Starting web host");
                builder.Host.UseSerilog((context, services, configuration) =>
                    configuration
                        .ReadFrom.Configuration(context.Configuration)
                        .ReadFrom.Services(services)
                        .Enrich.FromLogContext());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static void UseSerilogRequestLogging(this WebApplication? app)
        {
            app?.UseSerilogRequestLogging(x => x.MessageTemplate = "HTTP {RequestMethod} {RequestPath} with id {CorrelationId} responded {StatusCode} in {Elapsed:0.0000} ms");
        }
    }
}
