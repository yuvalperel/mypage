using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class Member
    {
        // Private fields
        private string memberID;
        private string name;
        private List<Book> borrowedBooks;

        // Public properties
        public string MemberID
        {
            get { return memberID; }
            set
            {
                if (IsValidId(value))
                {
                    memberID = value;
                }
                else
                {
                    Console.WriteLine("Invalid Member ID. It must be a 9-digit number.");

                }
            }
        }

        // Private method for validating the ID
        private bool IsValidId(string id)
        {
            // Check if the ID is 9 digits long
            if (id.Length != 9)
            {
                Console.WriteLine("ID must be 9 digits long");
                return false;
            }
            // Check if all characters are digits
            foreach (char c in id)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    Console.WriteLine("ID contains non-digit characters. It must only contain digits 0 to 9.");
                    return false;
                }
            }
            return true;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Book name cannot be empty.");
                }
                name = value;
            }
        }

        public List<Book> BorrowedBooks
        {
            get { return borrowedBooks; }
        } 

        // Constructor
        public Member(string memberId, string name)
        {
            MemberID = memberId;
            Name = name;
            borrowedBooks = new List<Book>();
        }

    }
}

