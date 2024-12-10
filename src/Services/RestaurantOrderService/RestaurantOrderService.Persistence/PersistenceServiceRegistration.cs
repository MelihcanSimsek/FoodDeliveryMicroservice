using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantOrderService.Persistence.Context;
using RestaurantOrderService.Persistence.Repositories;
using RestaurantOrderService.Application.Interfaces.Repositories;
using RestaurantOrderService.Application.Interfaces.UnitOfWorks;
using RestaurantOrderService.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantOrderService.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
