using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_OOP
{
    class car
    {
        public string model;     //  created a field
        public car() //class constructor
        {
            model = " g_wagon"; // initialize the value model
        }
    }
    class Student
    {
        static int RollNo;
        string Name;
        string Dept;
        float Marks;

        static string wish;

        public void AcceptStudent()
        {
            Console.WriteLine("Enter Student RollNo,Name,Dept and Marks :");
            RollNo = Convert.ToInt32(Console.ReadLine());
            Name = Console.ReadLine();
            Dept = Console.ReadLine();
            Marks = Convert.ToSingle(Console.ReadLine());
        }

        public void DisplayStudent()
        {
            Console.WriteLine($"Roll No :{RollNo}, Name : {Name}, Dept : {Dept} and Marks :{Marks}");
        }

        public static string Wishes(string s)
        {
            wish = s;
            return wish;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //car ford = new car();
            //Console.WriteLine(ford.model);




            //Student stud1 = new Student();  //calling the default constructor
            //stud1.AcceptStudent();
            //stud1.DisplayStudent();

            //Console.WriteLine(Student.Wishes("Hello this prog is completed"));

            //Console.WriteLine("-------------\n");




            //Student stud2 = new Student();
            //stud2.AcceptStudent();
            //stud2.DisplayStudent();
            //Console.WriteLine(Student.Wishes("Nice Choice"));




            Employee E = new Employee();
            E.DisplayEmp();
            Employee E2 = new Employee(1001,"ASHU",10000);
            E2.DisplayEmp();
            E = null; // object reference to null from a valid responce
            GC.Collect(); //forcefull collection of garbage the moment of the object looses reference
            Console.ReadKey();






            // access modiefies

            //Bike obj = new Bike();
            //Console.WriteLine(obj);// can be access within the class
            //Console.ReadLine();
        }
    }
}
