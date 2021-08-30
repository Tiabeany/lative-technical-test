namespace EmployeeDiscount.Application.Services.Interfaces
{
    public interface IEmployeeDiscountService
    {
        decimal GetEmployeeDiscountByAmount(decimal amount, int employeeId);
    }
}
