using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Interfaces.CustomMapper;
using OrderService.Infrastructure.CustomMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();
            return services;
        }
    }
}
