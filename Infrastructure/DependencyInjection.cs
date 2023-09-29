using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wbc.Application.Common.Interfaces;
using Wbc.Infrastructure.Persistence;
using Wbc.Infrastructure.Services;

namespace Wbc.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
                services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Wbc.CubeDb"));
            else
                services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IWbcSsoHttpClientService, WbcSsoHttpClientService>();
            services.AddTransient<ISsoService, SsoService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IWorkflowService, WorkFlowService>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<ILongRunningTaskProccesor, LongRunningTaskProcessor>();
            services.AddTransient<IDutyCalculatorService, DutyCalculatorService>();
          //  services.AddTransient<IDepreciationService, DepreciationService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IGeneralGoodsService, GeneralGoodsService>();
            services.AddTransient<ITariffManagerService, TariffManagerService>();
            return services;
        }
    }
}