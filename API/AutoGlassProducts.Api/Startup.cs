using AutoGlassProducts.Api.Extensions;
using AutoGlassProducts.TypeConverters.Extensions;
using AutoGlassProducts.Handlers.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning.ApiExplorer;
using Serilog;
using AutoGlassProducts.Api.Middlewares;
using AutoGlassProducts.Repositories.Extensions;
using AutoGlassProducts.Api.HostedServices;

namespace AutoGlassProducts.Api
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
            services.ConfigureAppLogging();
            services.ConfigureAppMapper();
            services.ConfigureRepositories();
            services.ConfigureHandlers();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoGlassProducts.Api", Version = "v1" });
                c.EnableAnnotations();

                // using System.Reflection;
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => c.IncludeXmlComments(xmlFile));
            });

            services.ConfigureAppVersioning();
            services.AddCors();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddHostedService<DatabaseConfigurationHostedService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider versionDescriptionProvider)
        {
            app.UseStaticFiles();
            
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    foreach (var description in versionDescriptionProvider.ApiVersionDescriptions)
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());

                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSerilogRequestLogging();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
