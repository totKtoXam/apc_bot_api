using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace apc_bot_api.Services
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "APC BOTs restAPI", Version = "v1.0" });

                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                //                 Enter 'Bearer' [space] and then your token in the text input below.
                //                 \r\n\r\nExample: 'Bearer 12345abcdef'",
                //     Name = "Authorization",
                //     In = ParameterLocation.Header,
                //     Type = SecuritySchemeType.ApiKey,
                //     Scheme = "Bearer"
                // });

                // c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                // {
                //     {
                //     new OpenApiSecurityScheme
                //     {
                //         Reference = new OpenApiReference
                //         {
                //             Type = ReferenceType.SecurityScheme,
                //             Id = "Bearer"
                //         },
                //         Scheme = "oauth2",
                //         Name = "Bearer",
                //         In = ParameterLocation.Header,

                //         },
                //         new List<string>()
                //     }
                // });
                // c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                // {
                //     Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //     Name = "Authorization",
                //     In = "header",
                //     Type = "apiKey"
                // });

                // c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                // {
                //     {
                //     new OpenApiSecurityScheme
                //     {
                //         Reference = new OpenApiReference
                //         {
                //             Type = ReferenceType.SecurityScheme,
                //             Id = "Bearer"
                //         },
                //         Scheme = "oauth2",
                //         Name = "Bearer",
                //         In = ParameterLocation.Header,

                //         },
                //         new List<string>()
                //     }
                // });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "APC BOTs restAPI v1.0");
                c.RoutePrefix = string.Empty;
                c.RoutePrefix = "api";
            });

            return app;
        }
    }
}