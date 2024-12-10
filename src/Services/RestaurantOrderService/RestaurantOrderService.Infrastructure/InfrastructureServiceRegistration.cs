using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderService.Application.Interfaces.CustomMapper;
using RestaurantOrderService.Infrastructure.CustomMapper;

namespace RestaurantOrderService.Infrastructure
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
