using EmployeeDiscount.Application.Services.Interfaces;
using EmployeeDiscount.Domain.Repositories;

namespace EmployeeDiscount.Application.Services
{
    public class EmployeeDiscountService : IEmployeeDiscountService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDiscountService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public decimal GetEmployeeDiscountByAmount(decimal amount, int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeByID(employeeId);
            employee.SetType();
            employee.SetDiscount(amount);
            return employee.Discount.Value;
        }
    }
}
