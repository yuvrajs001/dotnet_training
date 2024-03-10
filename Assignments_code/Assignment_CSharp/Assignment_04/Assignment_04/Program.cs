using System;
using Concession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment_04
{
    class Program
    {
        static void Main(string[] args)
        {

            //Answer of ClassLibrary

            TicketConcession ticket = new TicketConcession();
            Console.WriteLine("-----------Assignment 4 Started------------");
            Console.Write("Enter Your Name: ");
            ticket.Name = Console.ReadLine();

            Console.Write("Enter Your Age: ");
            ticket.Age = int.Parse(Console.ReadLine());

            ticket.CalConcession();



            //Lambda Query1
            // the

            Console.WriteLine("\n");
            Console.WriteLine("--------------Query 1 Started-------------");


            Console.Write("Enter a list of numbers separated by commas: ");
            string input = Console.ReadLine();

            List<int> numbers = input.Split(',').Select(int.Parse).ToList();

            List<int> result = NumberQuery1.NumberListInput(numbers);

            Console.WriteLine("Lambda Query Output: " + string.Join(", ", result));

            Console.WriteLine("--------------Query 2 Started-------------");



            //Words query question2


            Console.Write("Enter a sentence which contains the letter starting with a and m: ");
            string userInput = Console.ReadLine();
            WordsQuery2 Words = new WordsQuery2();

            List<string> QueryResult = Words.GetUserInputWords(userInput);

            Console.WriteLine($" Those Words who  starting with 'a' and ending with 'm': {string.Join(", ", QueryResult)}");



            Console.ReadKey();


        }
    }
}

   


