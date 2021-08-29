using System;
using System.Data.SqlClient;
using Dapper;

namespace EmployeeDiscount.UI
{
    public class Class1
    {
        public decimal Calc(decimal amnt, int uid)
        {
            int tp = 0;
            int y = 0;
            int part_t = 2;
            var connection = new SqlConnection("Data Source=SW-GBHA-TISL281;Initial Catalog=TWDC_CustDis;User Id=dev;Password=dev;");
            tp = connection.ExecuteScalar<int>("SELECT type FROM Employees WHERE id=" + uid);
            DateTime sd = connection.ExecuteScalar<DateTime>("SELECT start_date FROM Customers where id=" + uid);
           
            y = DateTime.Now.Year - sd.Year;

            decimal result = 0;
            decimal discB = (y > 5 ) ? (decimal)3 / 100 : (decimal)5 / 100;

            if (tp == 1) 
            {
                if (y > 3)
                {
                    result = (amnt * 10 / 100) - (decimal) 0.05 * (amnt * 10 / 100);
                }
                else
                {
                    result = (amnt * 10 / 100);
                }


            }
            else if (tp == part_t)
            {
                //(y > 5) ? (amnt * 10 / 100) - (decimal) 0.05 * (amnt * 10 / 100);
                decimal disc2 = (decimal) 3 / 100; 
                result = (y > 5) ? (amnt * 5 / 100) - disc2 * (amnt * 5 / 100) : (amnt * 5 / 100);
            }
            else if (tp == 3)
            {
                if (amnt > 30) 
                {
                    result = amnt * 5 / 100; 
                }
                else
                {
                    result = amnt;
                }
            }
            else if (tp == 4) 
            {

                result = amnt;
            }

            connection.Execute("UPDATE Employees SET discount=" + result + " WHERE id=" + uid);

            //return the result
            return result;
        }
    }
}
