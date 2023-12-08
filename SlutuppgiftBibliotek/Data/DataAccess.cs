using SlutuppgiftBibliotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutuppgiftBibliotek.Data
{
    internal class DataAccess
    {
        public void Seed()
        {
            Context context = new Context();
            Author author1 = new();
            author1.FirstName = "Astrid";
            author1.LastName = "Lindgren";
            Author author2 = new();
            author2.FirstName = "John";
            author2.LastName = "Smith";

            Borrower borrower1 = new Borrower
            {
                FirstName = "Nicole",
                LastName = "Sanchez",
                LibraryCard = "MY004",
                LibraryCardPin = 1234
            };
            Borrower borrower2 = new Borrower
            {
                FirstName = "Mike",
                LastName = "Yousif",
                LibraryCard = "MN008",
                LibraryCardPin = 5678
            };
            Book book1 = new Book
            {
                Title = "Pippi",
                ISBN = 123456789,
                IsAvailable = false,

            };
            context.Authors.AddRange(new List<Author>() { author1, author2 });
            context.Borrowers.AddRange(new List<Borrower>() {  borrower1, borrower2 });
            context.Books.AddRange(new List<Book>() { book1 });
            context.SaveChanges();


        }
    }
}
