using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wbc.Application.Common.Interfaces;

namespace Wbc.Infrastructure.Services
{
    public class LongRunningTaskService : BackgroundService
    {
        private readonly ILongRunningTaskChannel _subscriptionChannel;
        private readonly IServiceProvider _serviceProvider;

        public LongRunningTaskService(ILongRunningTaskChannel subscriptionChannel, IServiceProvider serviceProvider)
        {
            _subscriptionChannel = subscriptionChannel;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var fileId in _subscriptionChannel.ReadAllAsync(stoppingToken))
            {
                using var scope = _serviceProvider.CreateScope();

                var processor = scope.ServiceProvider.GetRequiredService<ILongRunningTaskProccesor>();

                await processor.ProcessFile(fileId, stoppingToken);


            }
        }
    }
}
