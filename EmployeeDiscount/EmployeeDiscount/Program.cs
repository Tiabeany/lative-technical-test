using System;

namespace EmployeeDiscount.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert Total Amount:");
            var amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Insert Employee Id:");
            var employeedId = int.Parse(Console.ReadLine());

            var discount = new Class1().Calc(amount, employeedId);
            Console.WriteLine($"Employee discounts should be: {discount}");
        }
    }
}
