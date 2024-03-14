using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment03
{
    public class Calculator
    {
        public delegate int CalcDelegate(int a, int b);

        public int PerformOperation(int choice, int num1, int num2)
        {
            CalcDelegate operation = GetOperation(choice);
            if (operation != null)
            {
                return operation(num1, num2);
            }
            else
            {
                throw new ArgumentException("Invalid choice");
            }
        }

        private CalcDelegate GetOperation(int choice)
        {
            switch (choice)
            {
                case 1:
                    return Addition;
                case 2:
                    return Subtraction;
                case 3:
                    return Multiplication;
                default:
                    return null;
            }
        }

        private int Addition(int a, int b)
        {
            return a + b;
        }

        private int Subtraction(int a, int b)
        {
            return a - b;
        }

        private int Multiplication(int a, int b)
        {
            return a * b;
        }
    }

    class TestCalculator
    {
        static void Main(string[] args)
        {

            Calculator calculator = new Calculator();

            Console.Write("Enter your choice (1 for addition , 2 for subtraction, or 3): ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            int result = calculator.PerformOperation(choice, num1, num2);
            Console.WriteLine($"Result: {result}");

            Console.Read();
        }
    }
}