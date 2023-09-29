using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Wbc.Api.Dependencies
{
    public static class SwaggerDependencyInjection
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                                   {
                                       c.SwaggerDoc("v1",
                                       new OpenApiInfo
                                           {
                                               Title = "Tariff Manager API",
                                               Version = "v1",
                                               Description = "Tariff Manager for West Blue Consulting",
                                               Contact = new OpenApiContact
                                                             {
                                                                 Name = "West Blue Consulting",
                                                                 Email = "developer@westblueconsulting.com",
                                                                 Url = new Uri("https://westblueconsulting.co.uk")
                                                             },
                                               License = new OpenApiLicense
                                                             {
                                                                 Name = "Use Under Copyright of WBC",
                                                                 Url = new Uri("https://westblueconsulting.co.uk")
                                                             }
                                           });

                                       c.AddSecurityDefinition("oauth2",
                                       new OpenApiSecurityScheme
                                           {
                                               Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                                               In = ParameterLocation.Header,
                                               Name = "Authorization",
                                               Type = SecuritySchemeType.ApiKey
                                           });

                                       c.OperationFilter<SecurityRequirementsOperationFilter>();

                                       var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                                       var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                                       c.IncludeXmlComments(xmlPath);
                                   });

            return services;
        }
    }
}
