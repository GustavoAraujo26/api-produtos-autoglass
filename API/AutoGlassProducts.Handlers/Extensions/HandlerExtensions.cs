using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System.Reflection;

namespace AutoGlassProducts.Handlers.Extensions
{
    /// <summary>
    /// Extensões para manipuladores do Mediator
    /// </summary>
    public static class HandlerExtensions
    {
        /// <summary>
        /// Configura a injeção de dependência para os manipuladores do Mediator
        /// </summary>
        /// <param name="services">Interface da coleção de serviços</param>
        public static void ConfigureHandlers(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromApplicationDependencies()
                .AddClasses(classes => classes.InNamespaces("AutoGlassProducts.Handlers.Contracts"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithTransientLifetime();
            });

            var configuration = new MediatRServiceConfiguration();
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration);
        }
    }
}
