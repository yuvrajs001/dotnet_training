using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day3
{
    class Program
    {
      
            static void Main(string[] args)
            {
                //create an instance of the Strings_Eg class
                Strings_Eg se = new Strings_Eg();
            //call the String_Ops method on the instance
            Strings_Eg.String_Ops();

            //wait for user input before exiting
            Console.ReadLine();
            }
        }
    }

