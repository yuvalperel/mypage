using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Book
    {
        // Enum for Book Genre
        public enum Genre
        {
            Mystery = 0,
            Fantasy = 1,
            Biography = 2,
            ScienceFiction = 3,
            Romance = 4,
            Thriller = 5,
            Adventure = 6,
        }

        // Enum for Book Author
        public enum Author
        {
            AgathaChristie = 0,
            JRRTolkien = 1,
            MarkTwain = 2,
            DouglasAdams = 3,
            NoraRoberts = 4,
            JackCarr = 5,
        }

        // Private fields
        private string bookname;
        private Genre bookgenre;
        private Author bookauthor;
        private DateTime publicationDate;
        private bool isBorrowed;
        private DateTime? dueDate; // Nullable DateTime

        // Public properties
        public string BookName
        {
            get { return bookname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Book name cannot be empty.");
                }
                bookname = value;
            }
        }

        public Genre BookGenre
        {
            get { return bookgenre; }
            set { bookgenre = value; }
        }

        public Author BookAuthor
        {
            get { return bookauthor; }
            set { bookauthor = value; }
        }

        public DateTime PublicationDate
        {
            get { return publicationDate; }
            set
            {
                if (value <= DateTime.Today)
                {
                    publicationDate = value;
                }
                else
                {
                    throw new ArgumentException("Publication date cannot be in the future.");
                }
            }
        }

        public bool IsBorrowed
        {
            get { return isBorrowed; }
            set { isBorrowed = value; }
        }

        public DateTime? Duedate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }


        // Constructors
        public Book(string name, Genre genre, Author author, DateTime publicationDate)
        {
            BookName = name;
            BookGenre = genre;
            BookAuthor = author;
            PublicationDate = publicationDate;
            IsBorrowed = false;
            dueDate = null; // No due date when book is not borrowed
        }

        public Book(string name, Genre genre, Author author, DateTime publicationDate, bool isBorrowed)
        {
            BookName = name;
            BookGenre = genre;
            BookAuthor = author;
            PublicationDate = publicationDate;
            IsBorrowed = isBorrowed;
            dueDate = isBorrowed? DateTime.Today.AddDays(14) : (DateTime?)null; // Set due date to 2 weeks from today if borrowed
        }

        /* Methods to add and delete a book
        public void AddBook()
        {
            Console.WriteLine($"{BookName} by {BookAuthor} added to the library.");
        }

        public void DeleteBook()
        {
            Console.WriteLine($"{BookName} by {BookAuthor} removed from the library.");
        }
        */
    }
}

