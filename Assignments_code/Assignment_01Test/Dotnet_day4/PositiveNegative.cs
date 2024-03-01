using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_day4
{
    class PositiveNegative
    {
        public void CalculatPosNeg()
        {
          
                int Num;

                Console.Write("\nCheck whether a number is positive or negative:\n");
                

                Console.Write("Input an Number ");
                Num = Convert.ToInt32(Console.ReadLine()); // Read the input 

                if (Num >= 0)
                {
                    Console.WriteLine("{0} is a positive number.\n", Num);
                }
                else
                {
                    Console.WriteLine("{0} is a negative number.\n", Num);
                }
            Console.ReadKey();
            }
        }

    }
