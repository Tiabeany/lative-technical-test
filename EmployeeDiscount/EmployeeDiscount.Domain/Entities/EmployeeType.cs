namespace EmployeeDiscount.Domain.Entities
{
    public class EmployeeType
    {
        public int TypeNumber { get; set; }
        public EmployeeTypeDiscountParameters DiscountParameters { get; set; }

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
                case 1:
                    DiscountParameters = new EmployeeTypeDiscountParameters((decimal)0.10, (decimal)0.05, 5, 0);
                    break;
                // Part-Time
                case 2:
                    DiscountParameters = new EmployeeTypeDiscountParameters((decimal)0.05, (decimal)0.03, 5, 0);
                    break;
                // Intern
                case 3:
                    DiscountParameters = new EmployeeTypeDiscountParameters((decimal)0.10, (decimal)0.05, 5, 30);
                    break;
                // Contractor and others
                case 4:
                default:
                    DiscountParameters = new EmployeeTypeDiscountParameters(0, 0, 0, 0);
                    break;
            }
        }
    }
}
