using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day7
{
    class exception_eg
    { 
            static void Main(string[] args)
            {
                int Number1, Number2, Result;
                try
                {
                    Console.WriteLine("Enter First Number:");
                    Number1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Second Number:");
                    Number2 = int.Parse(Console.ReadLine());
                    Result = Number1 / Number2;
                    Console.WriteLine($"Result = {Result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Message: {ex.Message}");
                    Console.WriteLine($"Source: {ex.Source}");
                    Console.WriteLine($"HelpLink: {ex.HelpLink}");
                    Console.WriteLine($"StackTrace: {ex.StackTrace}");
                }
                Console.ReadKey();
            }
        }
    }

