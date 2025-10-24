using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Book
    {
        string bookId;
        string title;
        string author;
        bool isIssued;
        public Book(string bookId, string title, string author, bool isIssued=false) {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.isIssued = false;
        }
        public void IssueBook()
        {
            this.isIssued=true;
            Console.WriteLine("BOOK ISSUED");
        }
        public void ReturnBook() 
        {
            this.isIssued = false;
            Console.WriteLine("BOOK RETURNED");
        }
        public void DisplayBookDetails()
        {
            Console.WriteLine("BOOK ID: " + bookId);
            Console.WriteLine("BOOK TITLE: " + title);
            Console.WriteLine("BOOK AUTHOR: " + author);
            Console.WriteLine("BOOK IS ISSUED?: " + isIssued);
        }
    }
}
