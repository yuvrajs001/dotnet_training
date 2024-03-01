using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day6
{
    class indexer_ex1
    {

        private string[] studentName = new string[10]; // Declare an array to store elements

        // Define an indexer
        public string this[int index]
        {
            get
            {
                // Return value stored at studentName array
                return studentName[index];
            }
            set
            {
                // Assigns value to studentName
                studentName[index] = value;
            }
        }

        public static void Main()
        {
            // Create an instance of the  class
            indexer_ex1 obj = new indexer_ex1();

            // Insert values in obj[] using indexer (index position)
            obj[0] = "Harry";
            obj[1] = "Ron";

            Console.WriteLine("First element in obj: " + obj[0]);
            Console.WriteLine("Second element in obj: " + obj[1]);
        }
    }

}