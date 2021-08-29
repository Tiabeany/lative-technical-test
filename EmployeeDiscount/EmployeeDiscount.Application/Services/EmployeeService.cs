using EmployeeDiscount.Domain.Repositories;

namespace EmployeeDiscount.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public decimal GetEmployeeDiscoutByAmount(decimal amount, int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeByID(employeeId);
            employee.SetDiscount(amount);
            return employee.Discount.Value;
        }
    }
}
