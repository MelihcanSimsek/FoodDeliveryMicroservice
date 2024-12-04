using CourierService.Application.Interfaces.CustomMapper;
using CourierService.Infrastructure.CustomMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Infrastructure
{
    public static class Registrations
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();

            return services;
        }
    }
}
