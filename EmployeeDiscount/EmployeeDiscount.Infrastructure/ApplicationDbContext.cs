using EmployeeDiscount.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDiscount.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeeTypeDiscountRule> EmployeeTypeDiscounts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
