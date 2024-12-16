using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Menu.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Liquid> Liquids { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
