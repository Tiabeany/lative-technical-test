using EmployeeDiscount.Domain.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDiscount.Domain.Entities
{
    public class Employee : IAggregateRoot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [Required]
        public DateTime StartDate { get; private set; }
        [Required]
        public int EmployeeTypeNumber { get; private set; }
        public decimal? Discount { get; private set; }

        [NotMapped]
        public EmployeeType EmployeeType { get; private set; }

        private Employee(int id, int employeeTypeNumber, DateTime startDate, decimal? discount)
        {
            Id = id;
            Discount = discount;
            StartDate = startDate;
            EmployeeTypeNumber = employeeTypeNumber;
        }

        public Employee(int id, int employeeTypeNumber, EmployeeType employeeType, DateTime startDate, decimal? discount)
        {
            Id = id;
            EmployeeType = employeeType;
            EmployeeTypeNumber = employeeTypeNumber;
            Discount = discount;
            StartDate = startDate;
        }

        public void SetType()
        {
            EmployeeType = new EmployeeType(EmployeeTypeNumber);
        }

        public void SetDiscount(decimal totalAmount)
        {
            if (totalAmount > EmployeeType.DiscountRule.MinimumPrice)
            {
                var discountPercentage = EmployeeType.DiscountRule.Discount;
                var extraDiscountPercentage = EmployeeType.DiscountRule.ExtraDiscount;
                var yearsNeededForExtraDiscount = EmployeeType.DiscountRule.YearsNeededForExtraDiscount;

                var employedYearsInCustomer = DateTime.Now.Year - StartDate.Year;

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
