

using BasketService.Application.Interfaces.Repositories;
using BasketService.Persistence.RedisEntity;
using BasketService.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasketService.Persistence
{
    public static class Registrations
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));
            services.AddTransient<ICustomerBasketRepository, CustomerBasketRepository>();

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisSettings:ConnectionString"];
                opt.InstanceName = configuration["RedisSettings:InstanceName"];
            });

            return services;
        }

    }
}
