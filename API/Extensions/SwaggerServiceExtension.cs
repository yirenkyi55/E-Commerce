using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtension
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            //Add swagger service
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Skinet API", Version = "v1" });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Skinet API V1");
            });
            return app;
        }

    }
}