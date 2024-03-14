using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment03
{
    class Append
    {
            static void Main()
            {
                Console.WriteLine("Enter the file name.");
                string fileName = Console.ReadLine();

                Console.WriteLine("Enter the text to append you want to append:");
                string textToAppend = Console.ReadLine();

                try
                {
                    // Append text to the file. If the file doesn't exist, it will be created automatically.
                    File.AppendAllText(fileName, textToAppend + Environment.NewLine);

                    Console.WriteLine("Text appended to the file successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while appending to the file. ");
                }
               Console.Read();
            }
        }
    }
