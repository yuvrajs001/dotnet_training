using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_test
{
    // answer 2


/*Create a Class called Products with Productid, 
        Product Name, Price. Accept 10 Products, sort 
        based on the price, and display the sorted Products*/
  
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
   

    class ProductSorting
    {
        static void Main()
        {
            List<Product> products = GetUserInputProducts();

            // Sort products based on their price
            var sortedProduc = products.OrderBy(product => product.Price);

            // Display sorted products 
            Console.WriteLine("sorted the product on their prices:");

            foreach (var product in sortedProduc)
            {
                Console.WriteLine($"ProductID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.Price}");
            }
            Console.ReadKey();
        }

        static List<Product> GetUserInputProducts()
        {
            List<Product> products = new List<Product>();

            Console.WriteLine("Enter details for 10 products:");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Product {i}:");
                Console.Write(" Enter your Product ID: ");
                int productId = int.Parse(Console.ReadLine());
                Console.Write("Enter your Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("What price do you want to give for this product : ");
                double price = double.Parse(Console.ReadLine());

                products.Add(new Product { ProductId = productId, ProductName = productName, Price = price });
                
            }

            return products;
        }
    }
}
