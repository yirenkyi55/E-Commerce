
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            //Register scopes for the repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}