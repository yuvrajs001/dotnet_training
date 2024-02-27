using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day5_OOP
{
    class Employee
    {
       
        
            int EmpId;
        string EmpName;
        double EmpSalary;

        internal Employee()   //private constructor, cannot be called outside the class
        {
            EmpId = 100;
            EmpName = "Mahesh";
            EmpSalary = 35000;
        }

        internal Employee(int eid, string ename)
        {
            EmpId = eid;
            EmpName = ename;
        }

        public Employee(int EmpId, string EmpName, double EmpSalary)
        {
            this.EmpId = EmpId;
            this.EmpName = EmpName;
            this.EmpSalary = EmpSalary;
        }

        public void DisplayEmp()
        {
            Console.WriteLine($"Empid {EmpId}, empname {EmpName} and salary is {EmpSalary}");
        }

        ~Employee()
        {
            Console.WriteLine("bye");
            Console.Read();
        }
    }
}
