using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDiscount.Domain.Entities
{
    [NotMapped]
    public class EmployeeTypeDiscountRule
    {
        public decimal Discount { get; private set; }
        public decimal ExtraDiscount { get; private set; }
        public int YearsNeededForExtraDiscount { get; private set; }
        public int MinimumPrice { get; private set; }

        public EmployeeTypeDiscountRule(decimal discount, decimal extraDiscount, int yearsNeededForExtraDiscount, int minimumPrice)
        {
            Discount = discount;
            ExtraDiscount = extraDiscount;
            YearsNeededForExtraDiscount = yearsNeededForExtraDiscount;
            MinimumPrice = minimumPrice;
        }
    }
}
