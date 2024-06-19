using Microsoft.Extensions.DependencyInjection;
using AutoGlassProducts.TypeConverters.Extensions;
using AutoGlassProducts.Handlers.Extensions;

namespace AutoGlassProducts.Tests
{
    internal static class TestEnvironment
    {
        internal static IServiceCollection BuildEnvironment()
        {
            var services = new ServiceCollection();
            services.ConfigureAppMapper();
            services.ConfigureHandlers();
            
            return services;
        }

        public static T GetService<T>(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<T>();
        }
    }
}
