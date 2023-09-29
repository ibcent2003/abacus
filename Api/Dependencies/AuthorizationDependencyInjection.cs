using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Wbc.Api.Configuration;

namespace Wbc.Api.Dependencies
{
    public  static class AuthorizationDependencyInjection
    {
        public static IServiceCollection AddOidcAuthorization(this IServiceCollection services)
        {

            var adminApiConfiguration = services.BuildServiceProvider().GetService<AdminApiConfiguration>();

            services.AddAuthorization(options =>
                                      {
                                          options.AddPolicy(AuthorizationConsts.AdministrationPolicy,
                                              policy =>
                                              {
                                                  policy.RequireAuthenticatedUser();
                                                  policy.RequireClaim("scope", adminApiConfiguration.OidcApiName);
                                              });
                                      });
            return services;

        }
    }
}

