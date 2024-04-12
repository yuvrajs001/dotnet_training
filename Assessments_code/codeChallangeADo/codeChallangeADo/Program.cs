using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeChallangeADo
{
    class Program
    {
        static CodeChallangeEntities db = new CodeChallangeEntities();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Code challange Assessment ADO");

            Console.Write("\nEnter what you want to perform: ");
            Console.WriteLine("\n enter 1 for add the employee");
            Console.WriteLine("\n enter 2 for show the employee");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddEmployee();
                    break;
                case "2":
                   ShowEmployee();
                    break;
                default:
                    Console.WriteLine(" Please enter a valid option.");
                    break;
            }
            Console.ReadKey();
        }
        static void AddEmployee()
        {
            try
            {
                Console.WriteLine("\nEnter Employee Name");
                string empName = (Console.ReadLine());

                Console.Write("\nEnter Employee Salary it show be more than 25k ");
                decimal empsal = decimal.Parse(Console.ReadLine());

                Console.Write("\n Enter Employee type Type (Y)=FOR permannet and ,N for contract ");
                string empType = Console.ReadLine();

                db.AddEmployeeDetails(empName, empsal, empType);
                Console.WriteLine("Employee Addedd success");
                ShowEmployee();
                db.SaveChanges();

             
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void ShowEmployee()
        {
            try
            {

                var employees = db.ShowAllEmployee().ToList();
                Console.WriteLine("\nEmployees:");
                foreach (var emp in employees)
                {
                    Console.WriteLine($"Empno: {emp.Empno}, Name: {emp.EmpName}, Salary: {emp.Empsal}, Type: {emp.Emptype}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
       