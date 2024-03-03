using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Assignmet02
{
  
        class Saledetails
        {
            private int SalesNo;
            private int ProductNo;
            private float Price;
            private string DateofSale;
            private int Qty;
            private float TotalAmount;

            // Constructor initialization
            public Saledetails(int salesNo, int productNo, float price, int qty, string dateofSale)
            {
                SalesNo = salesNo;
                ProductNo = productNo;
                Price = price;
                Qty = qty;
                DateofSale = dateofSale;
                Sales();  // Calculate TotalAmount immediately upon object creation
            }

            // Method to calculate TotalAmount
            private void Sales()
            {
                TotalAmount = Qty * Price;
            }

            // Method to display data
            public void ShowData()
            {
                Console.WriteLine($"SalesNo: {SalesNo}");
                Console.WriteLine($"ProductNo: {ProductNo}");
                Console.WriteLine($"Price: {Price}");
                Console.WriteLine($"Qty: {Qty}");
                Console.WriteLine($"DateofSale: {DateofSale}");
                Console.WriteLine($"TotalAmount: {TotalAmount}");
            }

            // Static method to get the sales details from the user
            public static Saledetails GetSalesDetails()
            {
                Console.Write("Enter the SalesNo: ");
                int salesNo = int.Parse(Console.ReadLine());

                Console.Write("Enterthe ProductNo: ");
                int productNo = int.Parse(Console.ReadLine());

                Console.Write("Enter the Price: ");
                float price = float.Parse(Console.ReadLine());

                Console.Write("Enter the  Qty: ");
                int qty = int.Parse(Console.ReadLine());

                Console.Write("Enter the DateofSale: ");
                string dateofSale = Console.ReadLine();

                return new Saledetails(salesNo, productNo, price, qty, dateofSale);
            }
        }

        class SalesDetailsProgram
        {
            static void Main()
            {
                // Get sales details from the user as input
                Saledetails sale1 = Saledetails.GetSalesDetails();

                // Disply all thed Data
                sale1.ShowData();

                Console.ReadKey();
            }
        }
}
