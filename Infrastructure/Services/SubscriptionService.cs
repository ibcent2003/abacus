using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.Common.Models;

namespace Wbc.Infrastructure.Services
{
    public class SubscriptionService : ISubscriptionService
    {

        private readonly SubscriptionServiceConfiguration _subscriptionServiceConfiguration;
        private readonly AdminConfiguration _adminConfiguration;
        private readonly IWbcSsoHttpClientService _clientService;

        public SubscriptionService(AdminConfiguration adminConfiguration, IConfiguration configuration, IWbcSsoHttpClientService clientService, SubscriptionServiceConfiguration subscriptionServiceConfiguration)
        {
            _adminConfiguration = adminConfiguration;
            _clientService = clientService;
            _subscriptionServiceConfiguration = subscriptionServiceConfiguration;
        }

        public async Task<Subscriber> SubscribeAsync(Subscriber subscriber, CancellationToken cancellationToken)
        {
            var postUrl = $"{_subscriptionServiceConfiguration.SubscriptionServiceBaseUrl}{_subscriptionServiceConfiguration.SubscribePostUrl}";
            return await _clientService.PostWithTokenAsync<Subscriber>(subscriber, _adminConfiguration.SubscriptionApiScope, postUrl, cancellationToken);

        }

    }
}
