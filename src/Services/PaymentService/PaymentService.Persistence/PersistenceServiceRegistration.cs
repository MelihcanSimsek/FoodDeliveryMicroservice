using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaymentService.Application.Interfaces.Repositories;
using PaymentService.Application.Interfaces.UnitOfWorks;
using PaymentService.Persistence.Repositories;
using PaymentService.Persistence.UnitOfWorks;
using PaymentService.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace PaymentService.Persistence
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
