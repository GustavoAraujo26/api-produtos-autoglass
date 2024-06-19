using AutoGlassProducts.Domain.Handlers.Product;
using Microsoft.Extensions.DependencyInjection;
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
                scan.FromAssembliesOf(typeof(ICreateProductHandler))
                .AddClasses(classes => classes.Where(x => x.Name.EndsWith("Handler")))
                .AsImplementedInterfaces()
                .WithTransientLifetime();
            });

            var configuration = new MediatRServiceConfiguration();
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration);
        }
    }
}
