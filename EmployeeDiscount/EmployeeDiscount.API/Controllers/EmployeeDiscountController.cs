using EmployeeDiscount.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDiscount.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDiscountController : ControllerBase
    {
        private readonly ILogger<EmployeeDiscountController> _logger;
        private readonly IEmployeeDiscountService _employeeDiscountService;

        public EmployeeDiscountController(ILogger<EmployeeDiscountController> logger, IEmployeeDiscountService employeeDiscountService)
        {
            _logger = logger;
            _employeeDiscountService = employeeDiscountService;
        }

        [HttpGet]
        public decimal GetDiscount(decimal amount, int employeeId)
        {
            return _employeeDiscountService.GetEmployeeDiscountByAmount(amount, employeeId);
        }
    }
}
