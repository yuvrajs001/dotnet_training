using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day6
{
    class Employee
    {
        string _code = "N.A.";
        string _name = " missing";
        int _age = 0;


        // index array prop writing
        string[] projectData;
        //automatic property implement
        public double Salary {  get; } = 20000;
        // declare prop for private fields
        public  string Code
        {
            get { return _code; }//reads the value of the field
            set { _code = value; }//write,set,manipulate the value of the field

        }
        //read only prop(whre ther is only getter and no setter)

        public int Age
        {
            get { return _age; }
        }
       
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != " ")
                    _name = value;
                else
                    Console.WriteLine("Invalid Data");
            }
        }


        //WE Need to override the tostring() of the object class

        public override string ToString()
        {
            return "Employee Code=  " + Code + "Name =   " + Name + "   and Age =   " + Age;

        }
        
    }


    class properties
    {

        public static void Main()
        {
            Employee emp = new Employee();
            emp.Code = "E003";// it will call the setter
            
            Console.WriteLine(emp.Code);//it will call the getter

            Console.WriteLine(emp.Age);
            emp.Name = "radha";
            Console.WriteLine("EMPLOYEE DATA: {0}",emp.ToString());
            
            Console.Read();
            
            
        }

    }
}
