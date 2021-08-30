using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDiscount.Domain.Entities
{
    [NotMapped]
    public class EmployeeType
    {
        public int TypeNumber { get; private set; }

        public EmployeeTypeDiscountRule DiscountRule { get; private set; }

        public EmployeeType(int typeNumber)
        {
            TypeNumber = typeNumber;
            SetDiscountParameters();
        }

        private void SetDiscountParameters()
        {
            switch (TypeNumber)
            {
                // Permanent
                case 0:
                    DiscountRule = new EmployeeTypeDiscountRule((decimal)0.10, (decimal)0.05, 5, 0);
                    break;
                // Part-Time
                case 1:
                    DiscountRule = new EmployeeTypeDiscountRule((decimal)0.05, (decimal)0.03, 5, 0);
                    break;
                // Intern
                case 2:
                    DiscountRule = new EmployeeTypeDiscountRule((decimal)0.10, (decimal)0.05, 5, 30);
                    break;
                // Contractor and others
                case 3:
                default:
                    DiscountRule = new EmployeeTypeDiscountRule(0, 0, 0, 0);
                    break;
            }
        }
    }
}
