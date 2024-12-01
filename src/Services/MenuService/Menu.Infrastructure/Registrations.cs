using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.RedisCache;
using Menu.Infrastructure.CustomMapper;
using Menu.Infrastructure.RedisCache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Infrastructure
{
    public static class Registrations
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<RedisSettings>(configuration.GetSection("RedisSettings"));
            services.AddTransient<IRedisCacheService, RedisCacheService>();

            services.AddSingleton<IMapper, Mapper>();

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisSettings:ConnectionString"];
                opt.InstanceName = configuration["RedisSettings:InstanceName"];
            });

            return services;
        }
    }
}
