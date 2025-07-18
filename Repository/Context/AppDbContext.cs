using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CompanyEntityTypeConfigurations());
            builder.ApplyConfiguration(new EmployeeEntityTypeConfigurations());
        }

    }
}
