using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Assignmet02
{

    /*        Answer 4
         
point 1: Create a class called Customer with Customerid, Name, Age, Phone,City.
point2:Write a constructor with no arguments and another constructor with all information.  
point 3:  Write a method called DisplayCustomer(), which is called directly without any object. Also  include destructor '

    */

    

    class Customer
    {
        // Point 1: Properties
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        // Point 2: Constructors
        // Constructor with no arguments
        public Customer()
        {
            // Default constructor
        }

        // Constructor with all information
        public Customer(int customerId, string name, int age, string phone, string city)
        {
            CustomerId = customerId;
            Name = name;
            Age = age;
            Phone = phone;
            City = city;
        }

        // Point 3: Method to display customer information
        public static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("Displaying Customer Information:");
            Console.WriteLine($"Customer ID: {customer.CustomerId}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Age: {customer.Age}");
            Console.WriteLine($"Phone: {customer.Phone}");
            Console.WriteLine($"City: {customer.City}");
        }

        // Destructor
        ~Customer()
        {
            Console.WriteLine($"Customer object with ID {CustomerId} is being destroyed.");
        }
    }

    class CustomerProgram
    {
        static void Main()
        {
          
            Customer customer1 = new Customer(1, "Yuvraj singh", 25, "1234567890", "Village");

            // Display customer information using the static method
            Customer.DisplayCustomer(customer1);

            Console.ReadKey();
        }
    }

}

