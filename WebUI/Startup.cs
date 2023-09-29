using System.Net.Http;
using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptimaJet.Workflow.Core.Runtime;
using Wbc.Application;
using Wbc.Application.Common.Interfaces;
using Wbc.Infrastructure;
using Wbc.Infrastructure.Persistence;
using Wbc.Infrastructure.Services;
using Wbc.WebUI.Dependencies;
using Wbc.WebUI.Services;


namespace Wbc.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public WorkflowRuntime Runtime { get; private set; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/StatusCodeError", "?code={0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
           
            Runtime = WorkflowInit.Create(app.ApplicationServices);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurations(Configuration);
            services.AddSingleton<HttpClient>();
            services.AddInfrastructure(Configuration);
            services.AddCubeLocalization();
            services.AddOidcAuthentication();
            services.AddTransient<IClaimsTransformation, PermissionToClaimsExtender>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddRazorPages().AddRazorRuntimeCompilation().AddMvcOptions(options => { options.Filters.Add(item: new AuthorizeFilter()); });
            services.AddApplication();
            services.AddSingleton<CommonLocalizationService>();
            services.AddAuthorization(options => { options.AddCubeAuthorizationPolicy(); });
            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
            //services.AddControllersWithViews(options => options.Filters.Add(new ApiExceptionFilter()));
           services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages();
            services.AddMvc(opt => { opt.EnableEndpointRouting = false; }).AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>()).AddViewLocalization(options => options.ResourcesPath = "Resources");
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireEtradeAdmin",
                     policy => policy.RequireRole("etrade Admin Tool"));
            });
            services.AddSingleton<ILongRunningTaskChannel, LongRunningTaskChannel>();
            services.AddHostedService<LongRunningTaskService>();
           // services.AddTransient<IDutyCalculatorService, DutyCalculatorService>();
            services.AddTransient<IVehicleService, VehicleService>();
           
        }
    }
}