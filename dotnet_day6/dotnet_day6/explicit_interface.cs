using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day6
{
    interface explicit_interface
    {

	}
    
         interface I1
	{

		void printMethod();
           	}

           	interface I2
	        {

		void printMethod();
	}

	// class C implements two interfaces
	class C : I1, I2
	{

		// Explicitly implements method of I1
		void I1.printMethod()
		{
			Console.WriteLine("I1 printMethod");
		}

		// Explicitly implements method of I2
		void I2.printMethod()
		{
			Console.WriteLine("I2 printMethod");
		}
	}

	// Driver Class
	class explicitTester
	{

		// Main Method
		static void Main(string[] args)
		{
			I1 i1 = new C();
			I2 i2 = new C();

			// call to method of I1
			i1.printMethod();

			// call to method of I2
			i2.printMethod();
			Console.ReadLine();
		}
	}

}
