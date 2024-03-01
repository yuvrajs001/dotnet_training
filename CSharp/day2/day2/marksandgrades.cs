using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    class marksandgrades
    {
       
            public void CalculateGrade()
            {
                // Declare variables
                int marks;
                string grade;

                // Prompt user for input
                Console.WriteLine("Enter your marks (0-100): ");
                marks = Convert.ToInt32(Console.ReadLine());

                // Use switch case to assign grade based on marks
                switch (marks)
                {
                    case int n when n >= 90:
                        grade = "A+";
                        break;
                    case int n when n >= 80:
                        grade = "A";
                        break;
                    case int n when n >= 70:
                        grade = "B+";
                        break;
                    case int n when n >= 60:
                        grade = "B";
                        break;
                    case int n when n >= 50:
                        grade = "C+";
                        break;
                    case int n when n >= 40:
                        grade = "C";
                        break;
                    case int n when n >= 30:
                        grade = "D";
                        break;
                    default:
                        grade = "F";
                        break;
                }

                // Display output
                Console.WriteLine("Your grade is: " + grade);
            Console.ReadKey();
            }
        }

    
}
