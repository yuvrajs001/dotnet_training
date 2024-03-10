using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Scholrship
    {
        public double Merit(int marks,double fees)
        {
            double amount = 0;
             if(marks>=70 && marks <= 80)
            {
                amount = 0.2 * fees;
                
            }else if(marks>80 && marks <= 90)
            {
                amount = 0.3 * fees;
            }
             else if (marks > 90)
            {
                amount = 0.5 * fees;
            }

            return amount;
        }
    }
    class ScholarshipCalc
    {
        public static void Main()
        {
            Console.WriteLine("-----------------------Answer4---------------");
            Scholrship scholrship = new Scholrship();
            Console.WriteLine("Enter the Marks: ");
            int marks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the fees: ");
            int fees = int.Parse(Console.ReadLine());
            double result = scholrship.Merit(marks,fees);
            Console.WriteLine($"Woww ,Finally you have recived the scholarship of : {result} ");
            Console.ReadKey();


        }
    }
}
