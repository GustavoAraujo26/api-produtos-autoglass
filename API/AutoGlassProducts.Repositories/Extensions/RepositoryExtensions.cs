using AutoGlassProducts.Domain.Repositories;
using AutoGlassProducts.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace AutoGlassProducts.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromApplicationDependencies()
                .AddClasses(classes => classes.InNamespaces("AutoGlassProducts.Repositories.Contracts"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithTransientLifetime();
            });

            services.Scan(scan =>
            {
                scan.FromAssemblies(
                    typeof(IProductRepository).Assembly,
                    typeof(ProductRepository).Assembly
                    )
                .AddClasses(classes => classes.Where(x => x.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithTransientLifetime();
            });
        }
    }
}
