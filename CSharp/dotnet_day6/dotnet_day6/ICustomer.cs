using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day6
{
     public interface ICustomer
    {
         void PrintCustRating(); // only declaration and no implementation
    }
    // one interface can implement other implements
    interface ICustomer1 :ICustomer
    {
        int getRating();
    }
    class customer : ICustomer
    {
      public void PrintCustRating()
        {
            Console.WriteLine("this is the ICustomer Rating");
        }
    }
    class interfaceTester 
    {
        public static void Main()
        {
            ICustomer ic;// CREATING AN INTERFACE OBJECT
                         // ic = new ICustomer; //can not instatitate an interface
            customer cust = new customer();
            cust.PrintCustRating();

            Console.ReadKey();
           }
    }
}
