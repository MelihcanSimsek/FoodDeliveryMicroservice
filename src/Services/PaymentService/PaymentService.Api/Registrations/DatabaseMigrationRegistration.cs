﻿using PaymentService.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace PaymentService.Api.Registrations
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
