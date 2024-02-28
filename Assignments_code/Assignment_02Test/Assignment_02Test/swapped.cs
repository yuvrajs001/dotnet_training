using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02Test
{
    class swapped
    {
      
            public void run()
            {
                Console.Write("Enter a string: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.Length < 2)
                {
                    Console.WriteLine("String length is less than 2. Swapping is not possible.");
                    return;
                }


                char firstChar = input[0];
                char lastChar = input[input.Length - 1];


                string swappedString = lastChar + input.Substring(1, input.Length - 2) + firstChar;

                Console.WriteLine($"Original String: {input}");
                Console.WriteLine($"Swapped String: {swappedString}");
            }
        }
    }

