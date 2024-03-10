using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //----------------Answer2---------------
    class LetterCounter
    {
        private string StringData;

        public LetterCounter(string input)
        {
            StringData = input;
        }
        // method to count the string
        public int CountOccurrences(char letter)
        {
            int count = 0;

            foreach (char c in StringData)
            {
                if (char.ToUpper(c) == char.ToUpper(letter))
                {
                    count++;
                }
            }

            return count;
        }
    }

    class CountOccurance
    {
        static void Main()
        {
            Console.Write("Enter a string: ");
            string StringData = Console.ReadLine();

            Console.Write("Enter the letter to be counted: ");
            char letterToCount = Console.ReadKey().KeyChar;// key char used to read single key from the console output
            Console.WriteLine(); 

            LetterCounter letterCounter = new LetterCounter(StringData);

            // display the result
            int count = letterCounter.CountOccurrences(letterToCount);
            Console.WriteLine($"The letter '{letterToCount}' occured {count} times in the string you have entered.");
            Console.ReadKey();
        }
    }
    }
