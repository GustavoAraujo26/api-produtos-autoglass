using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace AutoGlassProducts.Api.Providers
{
    internal class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(string name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            options.SwaggerGeneratorOptions.SwaggerDocs.Clear();

            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "AutoGlassProducts.Api",
                Version = description.ApiVersion.ToString(),
                Description = "API construída em .NET 5, para controle de produtos e seus fornecedores",
                Contact = new OpenApiContact
                {
                    Email = "gustavo.dearaujo26@gmail.com",
                    Url = new Uri("https://github.com/GustavoAraujo26/api-produtos-autoglass")
                }
            };

            if (description.IsDeprecated)
                info.Description += " This API version has been deprecated. Please use one of the new APIS available from explorer.";

            return info;
        }
    }
}
