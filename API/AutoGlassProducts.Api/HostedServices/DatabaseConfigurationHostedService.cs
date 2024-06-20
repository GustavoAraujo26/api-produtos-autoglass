using AutoGlassProducts.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoGlassProducts.Api.HostedServices
{
    internal sealed class DatabaseConfigurationHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DatabaseConfigurationHostedService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var repository = scope.ServiceProvider.GetRequiredService<IDatabaseConfigurationRepository>();
                        if (repository == null)
                            continue;

                        var creationCheckResponse = await repository.CheckConfiguration();
                        if (creationCheckResponse.IsSuccess)
                            break;

                        var databaseCreationResponse = await repository.Configure();
                        if (databaseCreationResponse.IsSuccess)
                            break;
                    }

                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) =>
            Task.CompletedTask;
    }
}
