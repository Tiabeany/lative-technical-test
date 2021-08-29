using System;
using System.Data.SqlClient;
using Dapper;

namespace EmployeeDiscount.UI
{
    public class Class1
    {
        public decimal Calc(decimal amount, int employeeId)
        {
            int type = 0;
            int yearsEmployed = 0;
            int partTimeType = 2;
            var connection = new SqlConnection("Data Source=SW-GBHA-TISL281;Initial Catalog=TWDC_CustDis;User Id=dev;Password=dev;");
            type = connection.ExecuteScalar<int>("SELECT type FROM Employees WHERE id=" + employeeId);
            DateTime employeeStartDate = connection.ExecuteScalar<DateTime>("SELECT start_date FROM Customers where id=" + employeeId);
           
            yearsEmployed = DateTime.Now.Year - employeeStartDate.Year;

            decimal discountAmount = 0;
            decimal extraDiscount = (yearsEmployed > 5) ? (decimal)3 / 100 : (decimal)5 / 100;

            if (type == 1) 
            {
                if (yearsEmployed > 3)
                {
                    discountAmount = (amount * 10 / 100) - (decimal) 0.05 * (amount * 10 / 100);
                }
                else
                {
                    discountAmount = (amount * 10 / 100);
                }


            }
            else if (type == partTimeType)
            {
                //(y > 5) ? (amnt * 10 / 100) - (decimal) 0.05 * (amnt * 10 / 100);
                decimal secondDiscount = (decimal) 3 / 100; 
                discountAmount = (yearsEmployed > 5) ? (amount * 5 / 100) - secondDiscount * (amount * 5 / 100) : (amount * 5 / 100);
            }
            else if (type == 3)
            {
                if (amount > 30) 
                {
                    discountAmount = amount * 5 / 100; 
                }
                else
                {
                    discountAmount = amount;
                }
            }
            else if (type == 4) 
            {

                discountAmount = amount;
            }

            connection.Execute("UPDATE Employees SET discount=" + discountAmount + " WHERE id=" + employeeId);

            //return the result
            return discountAmount;
        }
    }
}
