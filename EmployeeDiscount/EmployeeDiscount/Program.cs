using EmployeeDiscount.Application.Services;
using EmployeeDiscount.Infrastructure;
using EmployeeDiscount.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            Seed.SeedData(context);

            host.Run();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data source=employeediscount.db");

            var appDbContext = new ApplicationDbContext(optionsBuilder.Options);
            appDbContext.Database.Migrate();

            var employeeService = new EmployeeDiscountService(new EmployeeRepository(appDbContext));

            var discount = employeeService.GetEmployeeDiscoutByAmount(amount, employeedId);

            Console.WriteLine($"Employee discounts should be: {discount}");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
