using Microsoft.EntityFrameworkCore;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<PaymentCard> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
