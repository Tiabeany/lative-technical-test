using Microsoft.Graph;
using System.Collections.Generic;

namespace EmployeeDiscount.Domain.Entities
{
    public class EmployeeTypeDiscountRuleInEmployeeType : Entity
    {
        public EmployeeTypeDiscountRule EmployeeTypeDiscountRule { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public EmployeeTypeDiscountRuleInEmployeeType()
        {
        }

        public EmployeeTypeDiscountRuleInEmployeeType(EmployeeTypeDiscountRule employeeTypeDiscountRule, EmployeeType employeeType)
        {
            EmployeeType = employeeType;
            Employee = employee;
        }
    }
}
