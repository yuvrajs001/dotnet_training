using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01Test
{
    class EqualOrNot
    {
        public void CalculateEqual()
        {
            int num1, num2;
            Console.WriteLine("enter your first number : ");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input 2nd number: ");
            num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 == num2)  // Checking if int1 is equal to int2
                Console.WriteLine("{0} and {1} are equal.\n", num1, num2);
            else
                Console.WriteLine("{0} and {1} are not equal.\n", num1, num2);
            Console.ReadKey();
        }
    }
}
