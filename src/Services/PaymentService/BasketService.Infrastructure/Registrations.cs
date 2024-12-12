using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Infrastructure
{
    public static class Registrations
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services)
        {
         

            return services;
        }

    }
}
