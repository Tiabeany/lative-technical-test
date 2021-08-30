using EmployeeDiscount.Application.Services;
using EmployeeDiscount.Application.Services.Interfaces;
using EmployeeDiscount.Domain.Repositories;
using EmployeeDiscount.Infrastructure;
using EmployeeDiscount.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeDiscount.UI
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "DefaultConnection";
            services.AddDbContext<DbContext, ApplicationDbContext>(builder =>
                         builder.UseSqlServer(connectionString));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeDiscountService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
