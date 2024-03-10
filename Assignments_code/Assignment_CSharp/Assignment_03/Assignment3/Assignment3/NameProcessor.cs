using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //--------Answer1----------
    class NamePrint
    {
        public string Fname { get; set; }
        public string LName { get; set; }

        public NamePrint(string FirstName,string LastName)
        {
            Fname = FirstName;
            LName = LastName;
        }
        public static void Display(NamePrint namePrint)
        {
            Console.WriteLine(namePrint.Fname.ToUpper());
            Console.WriteLine(namePrint.LName.ToUpper());
        }
        public static NamePrint GetUserInput() 
        {
            Console.WriteLine("Enter Your First Name Sir");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name Sir");
            string LastName = Console.ReadLine();

            return new NamePrint(FirstName, LastName);
        }
        
    }
    class NameProcessor
    {
        static void Main(string[] args)
        {
             
            NamePrint Customer = NamePrint.GetUserInput();
            //access the first name and last name
            Console.WriteLine("first name: " + Customer.Fname);
            Console.WriteLine("last name" + Customer.LName);
            //displaying the names using display method
            NamePrint.Display(Customer);
            Console.ReadKey();
        }
    }
}
