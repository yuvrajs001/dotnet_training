using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{

    // ---------Answer1---------Run This Using Program.cs--------------

    class Books
    {
        // Members of the book class
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        // Constructor
        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }
        // Method to display book details
        public void Display()
        {
            Console.WriteLine($"Book Name : {BookName}, Author Name: {AuthorName}");
        }
        public void GetUserInput()
        {
            Console.WriteLine("Enter Book Name:");
            BookName = Console.ReadLine();

            Console.WriteLine("Enter Author Name:");
            AuthorName = Console.ReadLine();
        }
    }







    // using  collection class because we can store and access both 
    class BookCollection
    {
        private List<Books> books = new List<Books>();

        // Add a book to the collection
        public void AddBook(Books book)
        {
            books.Add(book);
        }

        // Indexer to access books
        public Books this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Count)
                    return books[index];
                else
                    throw new IndexOutOfRangeException("Index is out of range.");
            }
            set
            {
                if (index >= 0 && index < books.Count)
                    books[index] = value;
                else
                    throw new IndexOutOfRangeException("Index is out of range.");
            }
        }

        // Total  number of books in the collection
        public int Count
        {
            get { return books.Count; }
        }
    }






    // now creating the BookShelf to store the data and display the same using indexer
    class BookShelf
    {

        private BookCollection Collection = new BookCollection();
        public void AddBook(Books book)
        {
            Collection.AddBook(book);
        }

        // Method to display the details of all books on the shelf
        public void Display()
        {
            Console.WriteLine("Details of books on the shelf:");
            for (int i = 0; i < Collection.Count; i++)
            {
                Collection[i].Display();
            }

            

        }
    }
}
