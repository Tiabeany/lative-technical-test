using EmployeeDiscount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDiscount.Infrastructure
{
    public static class Seed
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (context.Employees.Any()) return;

            var employees = new List<Employee>();

            for (int i = 0; i < 20; i++)
            {
                var employeeId = i + 1;
                var employeeTypeNumber = i % 4;
                var yearsBackForStartDate = -(i % 8);
                var newEmployee = new Employee(employeeId, employeeTypeNumber, new EmployeeType(employeeTypeNumber), DateTime.Now.AddYears(yearsBackForStartDate), null);
                employees.Add(newEmployee);
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
