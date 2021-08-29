using EmployeeDiscount.Domain.Entities.Interfaces;
using System;

namespace EmployeeDiscount.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }
        public DateTime StartDate { get; private set; }

        public Customer(int id, DateTime startDate)
        {
            Id = id;
            StartDate = startDate;
        }
    }
}
