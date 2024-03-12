using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    using System;

    public class Employee
    {
        public int Empid { get; set; }
        public string Empname { get; set; }
        public float Salary { get; set; }

        public Employee(int empid, string empname, float salary)
        {
            Empid = empid;
            Empname = empname;
            Salary = salary;
        }

        public static Employee GetUserInput()
        {
            Console.WriteLine("Enter Employee Details:");
            Console.Write("Employee ID: ");
            int empid = int.Parse(Console.ReadLine());

            Console.Write(" Enter Employee Name: ");
            string empname = Console.ReadLine();

            Console.Write("nEnter Employee Salary: ");
            float salary = float.Parse(Console.ReadLine());

            return new Employee(empid, empname, salary);
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"ID: {Empid}, Name: {Empname}, Salary: {Salary}");
        }
    }

    public class ParttimeEmployee : Employee
    {
        public float Wages { get; set; }

        public ParttimeEmployee(int empid, string empname, float salary, float wages) : base(empid, empname, salary)
        {
            Wages = wages;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Wages: {Wages}");
        }
    }

    class EmployeeDetail
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Part-time Employee Details:");
            ParttimeEmployee pte = GetParttimeEmployeeInput();
           
            Console.WriteLine("\nEmployee Details:");
            Employee emp = Employee.GetUserInput();

            emp.DisplayDetails();
            pte.DisplayDetails();

            Console.Read();
        }

        static ParttimeEmployee GetParttimeEmployeeInput()
        {
            Console.Write(" Enter Employee ID: ");
            int empid = int.Parse(Console.ReadLine());

            Console.Write(" Enter Employee Name: ");
            string empname = Console.ReadLine();

            Console.Write(" Enter Employee Salary: ");
            float salary = float.Parse(Console.ReadLine());

            Console.Write(" Enter Employee Wages: ");
            float wages = float.Parse(Console.ReadLine());

            return new ParttimeEmployee(empid, empname, salary, wages);
            Console.ReadKey();
        }
        
    }

    
}
