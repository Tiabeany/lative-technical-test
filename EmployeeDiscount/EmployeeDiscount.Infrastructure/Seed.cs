using EmployeeDiscount.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDiscount.Infrastructure
{
    public static class Seed
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (context.Employees.Any()) return;

            var employees = new List<Employee>
            {
                new Employee(1, new EmployeeType(1), null),
                new Employee(2, new EmployeeType(2), null),
                new Employee(3, new EmployeeType(3), null),
                new Employee(4, new EmployeeType(4), null),
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
