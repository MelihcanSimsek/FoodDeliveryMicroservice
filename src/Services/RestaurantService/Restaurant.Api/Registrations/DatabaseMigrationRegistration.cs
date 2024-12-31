using Restaurant.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Restaurant.Api.Registrations
{
    public static class DatabaseMigrationRegistration
    {
        public static void MigrateDatabase(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
