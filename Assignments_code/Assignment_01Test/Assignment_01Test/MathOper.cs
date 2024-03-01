using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01Test
{
    class MathOper
    {
        public void CalculateOper()
        {
            int n1, n2;
            char operation;

            // User input for the first number
            Console.Write("Input first number: ");
            n1 = Convert.ToInt32(Console.ReadLine());


            Console.Write("Input operation: ");
            operation = Convert.ToChar(Console.ReadLine());

            // User input for the second number
            Console.Write("Input second number: ");
            n2 = Convert.ToInt32(Console.ReadLine());

            // Perform the arithmetic operation based on the operator entered
            switch (operation)
            {
                case '+':
                    Console.WriteLine($"{n1} + {n2} = {n1 + n2}");
                    break;
                case '-':
                    Console.WriteLine($"{n1} - {n2} = {n1 - n2}");
                    break;
                case '*':
                case 'x':
                    Console.WriteLine($"{n1} * {n2} = {n1 * n2}");
                    break;
                case '/':
                    Console.WriteLine($"{n1} / {n2} = {n1 / n2}");
                    break;
                default:
                    Console.WriteLine("Invalid operator entered. Please use +, -, *, or /.");
                    break;
            }
            Console.ReadKey();
        }
        }
}
