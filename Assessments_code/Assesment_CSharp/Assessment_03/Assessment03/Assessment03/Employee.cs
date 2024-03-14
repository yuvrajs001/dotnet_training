using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment03
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    public class EmployeeService
    {
        private List<Employee> empList;

        public EmployeeService(List<Employee> employees)
        {
            empList = employees;
        }

        
        
        public IEnumerable<Employee> GetAllEmployees()
        {
            return empList;
        }
        // query 1
        //
        public IEnumerable<Employee> GetEmployeesLocation(string location)
        {
            return empList.Where(emp => emp.City != location);
        }

        //query2
        //
        public IEnumerable<Employee> GetEmployeesTitle(string title)
        {
            return empList.Where(emp => emp.title == title);
        }

        //query3
        public IEnumerable<Employee> GetEmployeesByLastNameStartingWith(char startingChar)
        {
            return empList.Where(emp => emp.LName.StartsWith(startingChar.ToString()));
        }
    }

    public class EmployeeTest
    {
        static void Main(string[] srgs)
        {
            var empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FName = "Malcolm", LName = "Daruwalla", title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FName = "Asdin", LName = "Dhalla", title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FName = "Madhavi", LName = "Oza", title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
            new Employee { EmployeeID = 1004, FName = "Saba", LName = "Shaikh", title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
            new Employee { EmployeeID = 1005, FName = "Nazia", LName = "Shaikh", title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FName = "Amit", LName = "Pathak", title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1007, FName = "Vijay", LName = "Natrajan", title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FName = "Rahul", LName = "Dubey", title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1009, FName = "Suresh", LName = "Mistry", title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
            new Employee { EmployeeID = 1010, FName = "Sumit", LName = "Shah", title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
        };

            var employeeService = new EmployeeService(empList);

            // a. Display detail of all the employees
            DisplayEmployees(employeeService.GetAllEmployees(), "details of all employees:");

            // b. Display details of all the employees whose location is not Mumbai/

            DisplayEmployees(employeeService.GetEmployeesLocation("Mumbai"), "employees  location is not Mumbai:");

            // c.  employees whose title is AsstManager
            DisplayEmployees(employeeService.GetEmployeesTitle("AsstManager"), " employees whose title is AsstManager:");

            // d. employees whose Last Name starts with S
            DisplayEmployees(employeeService.GetEmployeesByLastNameStartingWith('S'), "Details of employees whose Last Name starts with S:");
        }

        static void DisplayEmployees(IEnumerable<Employee> employees, string message)
        {
            Console.WriteLine(message);
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmployeeID: {emp.EmployeeID}, FirstName: {emp.FName}, LastName: {emp.LName}, Title: {emp.title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
            }
            Console.WriteLine();
        }
    }
}

