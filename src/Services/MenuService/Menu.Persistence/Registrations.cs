using Menu.Application.Interfaces.Repositories;
using Menu.Persistence.Context;
using Menu.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Menu.Persistence
{
    public static class Registrations
    {
        public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            var mongoDatabase = new MongoClient(configuration.GetConnectionString("MongoConnection"))
                .GetDatabase(configuration.GetSection("DatabaseName").Value);

            services.AddDbContext<AppDbContext>(opt => opt.UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<ILiquidRepository, LiquidRepository>();

            return services;
        }
    }
}
