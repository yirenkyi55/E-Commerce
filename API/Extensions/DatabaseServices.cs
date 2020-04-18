
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace API.Extensions
{
    public static class DatabaseServices
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
           {
               options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
           });
            
            //Register Redis InMemory Services Connection
            services.AddSingleton<IConnectionMultiplexer>(option =>
            {
                var config = ConfigurationOptions
                                                .Parse(configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });
            
            //Register scopes for the repositories
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}