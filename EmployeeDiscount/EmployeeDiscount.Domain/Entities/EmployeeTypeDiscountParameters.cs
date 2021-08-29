using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDiscount.Domain.Entities
{
    public class EmployeeTypeDiscountParameters
    {
        public decimal Discount { get; private set; }
        public decimal ExtraDiscount { get; private set; }
        public int YearsNeededForExtraDiscount { get; private set; }
        public int MinimumPrice { get; set; }

        public EmployeeTypeDiscountParameters(decimal discount, decimal extraDiscount, int yearsNeededForExtraDiscount, int minimumPrice)
        {
            Discount = discount;
            ExtraDiscount = extraDiscount;
            YearsNeededForExtraDiscount = yearsNeededForExtraDiscount;
            MinimumPrice = minimumPrice;
        }
    }
}
