using EmployeeDiscount.Domain.Entities.Interfaces;
using System;

namespace EmployeeDiscount.Domain.Entities
{
    public class Employee : IAggregateRoot
    {
        public int Id { get; private set; }
        public Customer Customer { get; set; }
        public EmployeeType EmployeeType { get; private set; }
        public decimal? Discount { get; private set; }

        public Employee(int id, EmployeeType employeeType, decimal? discount)
        {
            Id = id;
            EmployeeType = employeeType;
            Discount = discount;
        }

        public void SetDiscount(decimal totalAmount)
        {
            if (totalAmount > EmployeeType.DiscountParameters.MinimumPrice)
            {
                var discountPercentage = EmployeeType.DiscountParameters.Discount;
                var extraDiscountPercentage = EmployeeType.DiscountParameters.ExtraDiscount;
                var yearsNeededForExtraDiscount = EmployeeType.DiscountParameters.YearsNeededForExtraDiscount;

                var employedYearsInCustomer = DateTime.Now.Year - Customer.StartDate.Year;

                var hasExtraDiscount = employedYearsInCustomer > yearsNeededForExtraDiscount;

                var totalDiscount = hasExtraDiscount ? discountPercentage + extraDiscountPercentage : discountPercentage;

                Discount = totalAmount * totalDiscount;
            }
            else
            {
                Discount = 0;
            }
        }
    }
}
