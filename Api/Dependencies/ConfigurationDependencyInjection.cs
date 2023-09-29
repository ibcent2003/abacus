using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wbc.Api.Services;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Interfaces;
using Wbc.Infrastructure.Services;

namespace Wbc.Api.Dependencies
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
            //var notificationConfiguration = configuration.GetSection(nameof(NotificationServiceConfiguration)).Get<NotificationServiceConfiguration>();
            //services.AddSingleton(notificationConfiguration);
            var workflowConfiguration = configuration.GetSection(nameof(WorkFlowServiceConfiguration)).Get<WorkFlowServiceConfiguration>();
            services.AddSingleton(workflowConfiguration);
            services.AddTransient<ILongRunningTaskChannel, LongRunningTaskChannel>();
            services.AddTransient<ITariffManagerService, TariffManagerService>();


            return services;
        }
    }
}
