using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the number of books to store on the shelf: ");
            int MaxBookCapacity= int.Parse(Console.ReadLine());

            // Create a BookShelf object
            BookShelf shelf = new BookShelf();

            // Input details for each book
            for (int i = 0; i <MaxBookCapacity ; i++)
            {
                Console.WriteLine($"Enter details for Book {i + 1}:");
                Books book = new Books("", ""); // Create a new Books object
                book.GetUserInput(); // Get user input for book details
                shelf.AddBook(book); // Add the book to the BookShelf
            }

            // Display the details of all books on the shelf
            shelf.Display();
            Console.ReadLine();
        }
    }
}
   