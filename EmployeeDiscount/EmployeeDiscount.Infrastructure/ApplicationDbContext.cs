using EmployeeDiscount.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDiscount.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Seed.SeedData(this);
        }
    }
}
