using EmployeeDiscount.Application.Services;
using EmployeeDiscount.Infrastructure;
using EmployeeDiscount.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeDiscount.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Total Amount:");
            var amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Insert Employee Id:");
            var employeedId = int.Parse(Console.ReadLine()); 
            
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=SW-GBHA-TISL281;Initial Catalog=TWDC_CustDis;User Id=dev;Password=dev;");

            var appDbContext = new ApplicationDbContext(optionsBuilder.Options);

            var employeeService = new EmployeeService(new EmployeeRepository(appDbContext));

            var discount = employeeService.GetEmployeeDiscoutByAmount(amount, employeedId);

            Console.WriteLine($"Employee discounts should be: {discount}");
        }
    }
}
