using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace AutoGlassProducts.Api.Extensions
{
    public static class LoggingExtensions
    {
        public static void ConfigureAppLogging(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                var logger = CreateAppLogger();

                builder.AddSerilog(logger);
            });
        }
        
        /// <summary>
        /// Cria uma nova instância do logger do Serilog
        /// </summary>
        /// <returns>Interface do logger do Serilog</returns>
        public static Serilog.ILogger CreateAppLogger()
        {
            var newLogger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("System", LogEventLevel.Information)
                .WriteTo.Console()
                .WriteTo.File("product-api-log.txt")
                .CreateLogger();

            return newLogger;
        }
    }
}
