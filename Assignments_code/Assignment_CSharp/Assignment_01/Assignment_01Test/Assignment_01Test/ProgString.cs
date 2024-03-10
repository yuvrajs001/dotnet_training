using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01Test
{
    class ProgString
    {
        public void strinProg()
        {

            Console.Write("Enter the first word: ");
            string firstWord = Console.ReadLine();

            Console.Write("Enter the second word: ");
            string secondWord = Console.ReadLine();

            bool Same = String.Equals(firstWord, secondWord, StringComparison.OrdinalIgnoreCase);

            if (Same)
            {
                Console.WriteLine("The words are the same.");
            }
            else
            {
                Console.WriteLine("The words are different.");
            }


            Console.WriteLine("---------------------------------------Next Prog----------------------------");


            Console.WriteLine("---------------------------------------Press   Enter----------------------------");
            Console.ReadKey();

        }
    }
    class length
    {
        public void lengthCal()
        {
            Console.Write("Enter a word: ");
            string inputWord = Console.ReadLine();

            int length = inputWord.Length;

            Console.WriteLine($"Length of the word: {length}");
            Console.ReadKey();
        }
    }
}
