using System.Linq;
using API.Error;
using API.Mappings;
using AutoMapper;
using Core.Interfaces;
using Infrastructure.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(ProductMapping));
            services.AddHttpContextAccessor();
            services.Configure<ApiBehaviorOptions>(setupAction =>
              {
                  setupAction.InvalidModelStateResponseFactory = context =>
                  {
                      var errors = context.ModelState
                                           .Where(e => e.Value.Errors.Any())
                                           .SelectMany(e => e.Value.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToArray();
                      var errorResponse = new ApiValidationErrorResponse() { Errors = errors };
                      return new UnprocessableEntityObjectResult(errorResponse);
                  };
              });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                    });
            });

            return services;
        }
    }
}