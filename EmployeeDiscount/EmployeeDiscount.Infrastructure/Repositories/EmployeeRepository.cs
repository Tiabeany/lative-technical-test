using EmployeeDiscount.Domain.Entities;
using EmployeeDiscount.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDiscount.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteEmployee(int EmployeeID)
        {
            throw new System.NotImplementedException();
        }

        public Employee GetEmployeeByID(int EmployeeId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == EmployeeId);
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees;
        }

        public void InsertEmployee(Employee Employee)
        {
            _context.Employees.Add(Employee);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee Employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
