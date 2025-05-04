using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static project.Book;

namespace project
{
    public class Library
    {
        public List<Book> Books { get; private set; } // List of books in the library
        public List<Member> Members { get; private set; } // List of existing members

        // Constructor
        public Library()
        {
            Books = new List<Book>(); // Initialize the Books list
            Members = new List<Member>(); // Initialize the Members list
        }

        // Method to add predefined books
        public void AddPredefinedBooks()
        { 
            // Agatha Christie
            Books.Add(new Book("Murder on the Orient Express", Genre.Mystery, Author.AgathaChristie, new DateTime(1934, 1, 1)));

            // J.R.R. Tolkien
            Books.Add(new Book("The Hobbit", Genre.Fantasy, Author.JRRTolkien, new DateTime(1937, 9, 21)));

            // Mark Twain
            Books.Add(new Book("Adventures of Huckleberry Finn", Genre.Adventure, Author.MarkTwain, new DateTime(1884, 12, 10)));

            // Douglas Adams
            Books.Add(new Book("The Hitchhiker's Guide to the Galaxy", Genre.ScienceFiction, Author.DouglasAdams, new DateTime(1979, 10, 12)));

            // Nora Roberts
            Books.Add(new Book("The Witness", Genre.Romance, Author.NoraRoberts, new DateTime(2012, 4, 17)));

            // Jack Carr
            Books.Add(new Book("The Terminal List", Genre.Thriller, Author.JackCarr, new DateTime(2018, 3, 6)));
        }

        // Method to borrow a book from the library
        public void BorrowBook(string memberID, string title)
        {
            Book book = Books.FirstOrDefault(b => b.BookName.Equals(title, StringComparison.OrdinalIgnoreCase));
            Member member = Members.FirstOrDefault(m => m.MemberID == memberID);

            if (book == null)
            {
                Console.WriteLine($"Book with title '{title}' not found.");
                return;
            }

            if (member == null)
            {
                Console.WriteLine($"Member with ID '{memberID}' not found.");
                return;
            }

            if (book.IsBorrowed)
            {
                Console.WriteLine($"{book.BookName} is currently borrowed. It will be available again on {book.Duedate}.");
                return;
            }

            // Add the book to the member's borrowed books list
            book.IsBorrowed = true;
            book.Duedate = DateTime.Today.AddDays(14); // Set return date to two weeks from today
            member.BorrowedBooks.Add(book);
            Console.WriteLine($"{member.Name} has borrowed {book.BookName}.");
        }

        // Method to return a book
        public void ReturnBook(string memberID, string title)
        {
            Book book = Books.FirstOrDefault(b => b.BookName.Equals(title, StringComparison.OrdinalIgnoreCase));
            Member member = Members.FirstOrDefault(m => m.MemberID == memberID);

            if (book == null)
            {
                Console.WriteLine($"Book with title '{title}' not found.");
                return;
            }

            if (member == null)
            {
                Console.WriteLine($"Member with ID '{memberID}' not found.");
                return;
            }

            if (!book.IsBorrowed)
            {
                Console.WriteLine($"The book {book.BookName} is already available.");
                return;
            }

            // Return the book
            book.IsBorrowed = false;
            book.Duedate = null; // Clear the return date
            member.BorrowedBooks.Remove(book);
            Console.WriteLine($"{member.Name} has returned {book.BookName}.");
        }

        // Method to list available books
        public void ListAvailableBooks()
        {
            Console.WriteLine("Available books:");
            foreach (var book in Books)
            {
                if (!book.IsBorrowed)
                {
                    Console.WriteLine($"{book.BookName} by {book.BookAuthor}");
                }
            }
        }

       /*  
        public void AddBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Cannot add a null book.");
                return;
            }

            if (string.IsNullOrWhiteSpace(book.BookName))
            {
                Console.WriteLine("Book name is missing.");
                return;
            }

            if (book.PublicationDate > DateTime.Today)
            {
                Console.WriteLine("Publication date cannot be in the future.");
                return;
            }

            Books.Add(book);
            Console.WriteLine($"Book '{book.BookName}' by {book.BookAuthor} added to the library.");
        }
       */
    }
}