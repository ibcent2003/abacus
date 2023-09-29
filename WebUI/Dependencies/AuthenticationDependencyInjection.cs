using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wbc.Application.Common.Configuration;
using Wbc.Application.Common.Enums;
using Wbc.Application.Common.Helper;
using Wbc.Application.Common.Interfaces;
using ClaimTypes = Wbc.Application.Common.Enums.ClaimTypes;

namespace Wbc.WebUI.Dependencies
{
    public static class AuthenticationDependencyInjection
    {

        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services)
        {
            var adminConfiguration = services.BuildServiceProvider().GetService<AdminConfiguration>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;

            }).AddCookie().AddOpenIdConnect(options =>
            {
                options.Authority = adminConfiguration.AuthenticationBaseUrl;
                options.ClientId = adminConfiguration.ClientId;
                options.ClientSecret = adminConfiguration.ClientSecret;
                foreach (var scope in adminConfiguration.Scope)
                {
                    options.Scope.Add(scope);
                }
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.ClaimActions.MapUniqueJsonKey("Role", "role");
                options.ClaimActions.MapUniqueJsonKey("Organisation_Id", "Organisation_Id");
                options.ResponseType = adminConfiguration.ResponseType;
                options.ResponseMode = adminConfiguration.ResponseMode;
                options.UsePkce = true;
                options.RequireHttpsMetadata = true;
               

            });

            return services;
        }
    }
}
