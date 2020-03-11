using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

using Swashbuckle.AspNetCore.Swagger;

namespace SaveYourSearchAPI.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("5.0.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title="MainAPi", Version="v1.0"});
                c.DescribeAllEnumsAsStrings();
                //c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                //    {
                //    Description="Main Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name="Authorization",
                //    In = "header",
                //    Type = "apiKey"


                //    });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {

                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Test");
            });
            return app;
        }
    }
}
