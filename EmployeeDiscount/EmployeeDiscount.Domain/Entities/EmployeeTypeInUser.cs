using System.Collections.Generic;

namespace EmployeeDiscount.Domain.Entities
{
    public class EmployeeTypeInUser : ValueObject
    {
        public int TypeNumber { get; private set; }

        public EmployeeTypeDiscountRule DiscountRule { get; private set; }

        public EmployeeTypeInUser(int typeNumber)
        {
            TypeNumber = typeNumber;
            SetDiscountParameters();
        }

        private void SetDiscountParameters()
        {
            switch (TypeNumber)
            {
                // Permanent
                case 1:
                    DiscountRule = new EmployeeTypeDiscountRule((decimal)0.10, (decimal)0.05, 5, 0);
                    break;
                // Part-Time
                case 2:
                    DiscountRule = new EmployeeTypeDiscountRule((decimal)0.05, (decimal)0.03, 5, 0);
                    break;
                // Intern
                case 3:
                    DiscountRule = new EmployeeTypeDiscountRule((decimal)0.10, (decimal)0.05, 5, 30);
                    break;
                // Contractor and others
                case 4:
                default:
                    DiscountRule = new EmployeeTypeDiscountRule(0, 0, 0, 0);
                    break;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DiscountRule;
            yield return TypeNumber;
        }
    }
}
