using EmployeeDiscount.Domain.Entities;
using System.Collections.Generic;

namespace EmployeeDiscount.Domain.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int EmployeeId);
        void InsertEmployee(Employee Employee);
        void DeleteEmployee(int EmployeeID);
        void UpdateEmployee(Employee Employee);
        void Save();
    }
}
