﻿using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace Wbc.Api.Dependencies
{
    public static class LocalizationDependencyInjection
    {
        public static IServiceCollection AddCubeLocalization(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
                                                           {
                                                               var supportedCultures = new[] { new CultureInfo("en-GB"), new CultureInfo("fr") };
                                                               options.DefaultRequestCulture = new RequestCulture("en-GB");
                                                               options.SupportedCultures = supportedCultures;
                                                               options.SupportedUICultures = supportedCultures;
                                                           });
            return services;
        }
    }
}
