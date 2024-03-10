using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_task
{

    //answer1
    abstract class Student
    {
        // Members
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        // Abstract method for Ispassed
        public abstract bool IsPassed(double grade);
    }

    // Subclass using method 
    class Undergraduate : Student
    {
        // Undergraduate boolean
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    // Subclass for graduate
    class Graduate : Student
    {
        // graduate boolean
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class StudentProg
    {
        static void Main(string[] args)
        {
            //instance
            Undergraduate undergraduate = new Undergraduate();

            Console.WriteLine("Enter undergraduate student details:");
            Console.Write(" Enter Your Name: ");
            undergraduate.Name = Console.ReadLine();
            Console.Write(" Enter Your Student ID: ");
            undergraduate.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.Write(" Enter Your Grade: ");
            undergraduate.Grade = Convert.ToDouble(Console.ReadLine());

            // Check if student passed
            bool isPassedUndergrad = undergraduate.IsPassed(undergraduate.Grade);
            Console.WriteLine($"{undergraduate.Name} {(isPassedUndergrad ? "passed" : "failed")}.");

            // instance of the Graduate class
            Graduate graduate = new Graduate();

            // Inputs
            Console.WriteLine("\nEnter graduate student details:");
            Console.Write("Name: ");
            graduate.Name = Console.ReadLine();
            Console.Write("Student ID: ");
            graduate.StudentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Grade: ");
            graduate.Grade = Convert.ToDouble(Console.ReadLine());

            // Check if student passed
            bool isPassedGrad = graduate.IsPassed(graduate.Grade);
            Console.WriteLine($"{graduate.Name} {(isPassedGrad ? "passed" : "failed")}.");
            
            Console.ReadKey();
        }
    }
}