using AutoGlassProducts.Api.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using ArchitectureTools.Responses;

namespace AutoGlassProducts.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = LoggingExtensions.CreateAppLogger();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var appResponse = ActionResponse<object>.InternalError(ex);

                response.StatusCode = (int)appResponse.Status;

                var result = JsonConvert.SerializeObject(appResponse);
                await response.WriteAsync(result);

                _logger.Error(ex, "An error ocurred when execute the request!");
            }
        }
    }
}
