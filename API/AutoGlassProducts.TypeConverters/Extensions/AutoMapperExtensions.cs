using AutoGlassProducts.TypeConverters.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlassProducts.TypeConverters.Extensions
{
    /// <summary>
    /// Extensões para AutoMapper
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Configura a injeção de dependência do AutoMapper
        /// </summary>
        /// <param name="services">Interface da coleção de serviços</param>
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntityProfile), typeof(ModelProfile), typeof(DtoProfile));
        }
    }
}
