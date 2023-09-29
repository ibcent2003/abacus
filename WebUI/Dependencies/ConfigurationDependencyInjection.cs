using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wbc.Application.Common.Configuration;

namespace Wbc.WebUI.Dependencies
{
    public static class ConfigurationDependencyInjection
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {

            var adminConfiguration = configuration.GetSection(nameof(AdminConfiguration)).Get<AdminConfiguration>();
            services.AddSingleton(adminConfiguration);
            var subscriptionConfiguration = configuration.GetSection(nameof(SubscriptionServiceConfiguration)).Get<SubscriptionServiceConfiguration>();
            services.AddSingleton(subscriptionConfiguration);
            var ssoConfiguration = configuration.GetSection(nameof(SsoServiceConfiguration)).Get<SsoServiceConfiguration>();
            services.AddSingleton(ssoConfiguration);
            var notificationConfiguration = configuration.GetSection(nameof(NotificationServiceConfiguration)).Get<NotificationServiceConfiguration>();
            services.AddSingleton(notificationConfiguration);
            var workflowConfiguration = configuration.GetSection(nameof(WorkFlowServiceConfiguration)).Get<WorkFlowServiceConfiguration>();
            services.AddSingleton(workflowConfiguration);

            return services;
        }
    }
}
