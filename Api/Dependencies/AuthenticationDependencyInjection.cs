using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Wbc.Api.Dependencies
{
    public static class AuthenticationDependencyInjection
    {
        public static IServiceCollection AddOidcAuthentication(this IServiceCollection services)
        {

            services.AddAuthentication(options =>
                                       {
                                           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                           options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                                       })
                .AddJwtBearer(options =>
                              {
                                  options.SaveToken = true;
                                  options.RequireHttpsMetadata = true;
                                  options.Authority = "https://dev-sso.etradehubs.com";
                                  options.Audience = "WbcSubscriptionApi";
                                  options.TokenValidationParameters = new TokenValidationParameters()
                                  {

                                      ValidateIssuerSigningKey = true,
                                      ValidateAudience = true,
                                      ValidateIssuer = false,
                                      ValidateLifetime = true,
                                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret")),
                                      ClockSkew = TimeSpan.FromMinutes(5)
                                  };
                              });



            return services;

        }
    }
}
