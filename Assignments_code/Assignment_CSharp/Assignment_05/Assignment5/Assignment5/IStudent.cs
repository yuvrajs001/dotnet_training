using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
// Interface definition
    public interface IStudent
    {
        // Properties
        int StudentId { get; set; }
        string Name { get; set; }

        // Method
        void ShowDetails();
    }

    // Dayscholar class implementing the interface
    public class DayScholar : IStudent
    {
        // Properties
        public int StudentId { get; set; }
        public string Name { get; set; }

        // Constructor
        public DayScholar(int studentId, string name)
        {
            StudentId = studentId;
            Name = name;
        }

        // Method implementation
        public void ShowDetails()
        {
            Console.WriteLine($"These ar dayscholar details:");
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine($"Name: {Name}");
        }
    }


    // Resident class implementing the interface
    public class Resident : IStudent
    {
        // Properties
        public int StudentId { get; set; }
        public string Name { get; set; }

        // Constructor
        public Resident(int studentId, string name)
        {
            StudentId = studentId;
            Name = name;
        }

        // Method 
        public void ShowDetails()
        {
            Console.WriteLine($"Resident Details are :-");
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine($" Name: {Name}");
        }
    }

    // Class responsible for handling user input
    public class UserInput
    {
        public static IStudent GetStudentDetails()
        {
            Console.WriteLine("Enter Student details:");
            Console.Write("Enter Student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();


            


            Console.WriteLine("Enter 1 for storing DayScholar Detail and Enter 2 for Resident");
            int studentType = int.Parse(Console.ReadLine());


            // Based on user input, create and return appropriate student object
            if (studentType == 1)
            {
                return new DayScholar(studentId, name);
            }
            else if (studentType == 2)
            {
                return new Resident(studentId, name);
            }
            else
            {
                throw new ArgumentException("Invalid student type.");
            }
        }
    }

    class StudentDetail
    {
        static void Main(string[] args)
        {
            // Get student details using the UserInput class
            IStudent student = UserInput.GetStudentDetails();
            
            // Display student details
            student.ShowDetails();
            
            Console.ReadKey();
        }
    }

}
