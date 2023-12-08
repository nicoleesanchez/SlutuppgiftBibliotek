using SlutuppgiftBibliotek.Migrations;
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
            
            // Författare
            Context context = new();
            
            Author author1 = new();
            author1.FirstName = "Astrid";
            author1.LastName = "Lindgren";
            Author author2 = new();
            author2.FirstName = "John";
            author2.LastName = "Smith";
            Author author3 = new();
            author3.FirstName = "J.K.";
            author3.LastName = "Rowling";
            Author author4 = new();
            author4.FirstName = "George";
            author4.LastName = "Orwell";
            Author author5 = new();
            author5.FirstName = "Jane";
            author5.LastName = "Austen";

            //Alla lånetagare
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
                LibraryCardPin = 5678,
            };
            Borrower borrower3 = new Borrower
            {
                FirstName = "Emilija",
                LastName = "Filipovic",
                LibraryCard = "EJ903",
                LibraryCardPin = 8472,
            };
            Borrower borrower4 = new Borrower
            {
                FirstName = "Sandra",
                LastName = "Dahlberg",
                LibraryCard = "KJ789",
                LibraryCardPin = 1098,
            };
            Borrower borrower5 = new Borrower
            {
                FirstName = "Nathalie",
                LastName = "Glad",
                LibraryCard = "HG762",
                LibraryCardPin = 6980,
            };

            //Böckerna i biblioteket
            Book book1 = new Book
            {
                Title = "Pippi",
                ISBN = 123456789,
                IsAvailable = true,
                Rating = "Good Book",
                PublishedYear = 2010,
            };
            Book book2 = new Book
            {
                Title = "Emil i lönneberga",
                ISBN = 987654321,
                IsAvailable = true,
                Rating = "Good Book",
                PublishedYear = 1980,
            };
            Book book3 = new Book
            {
                Title = "Harry Potter and the Philosopher's Stone",
                ISBN = 748903678,
                IsAvailable = true,
                Rating = "Bad Book",
                PublishedYear = 2009,
            };
            Book book4 = new Book
            {
                Title = "1984",
                ISBN = 726947923,
                IsAvailable = true,
                Rating = "Okey Book",
                PublishedYear = 1999,
            };
            Book book5 = new Book
            {
                Title = "Murder on the Orient Express",
                ISBN = 123897655,
                IsAvailable = true,
                Rating = "Scary Book",
                PublishedYear = 2008,
            };
            Book book6 = new Book
            {
                Title = "Pride and Prejudice",
                ISBN = 99887765,
                IsAvailable = true,
                Rating = "Cute Book",
                PublishedYear = 2018,
            };
            Book book7 = new Book
            {
                Title = "The Old Man and the Sea",
                ISBN = 55663489,
                IsAvailable = true,
                Rating = "Sad Book",
                PublishedYear = 2005,
            };
            Book book8 = new Book
            {
                Title = "Alkemisten",
                ISBN = 44889876,
                IsAvailable = true,
                Rating = "Banger Book",
                PublishedYear = 2012,
            };

            context.Authors.AddRange(new List<Author>() { author1, author2, author3, author4, author5 });
            context.Borrowers.AddRange(new List<Borrower>() { borrower1, borrower2, borrower3, borrower4, borrower5 });
            context.Books.AddRange(new List<Book>() { book1, book2, book3, book4, book5, book6, book7, book8 });
            context.SaveChanges();
        }
        public void AddAuthor(string FirstName, string LastName)
        {
            using (Context context = new())
            {
                Author newAuthor = new Author
                {
                    FirstName = FirstName,
                    LastName = LastName
                };

                context.Authors.Add(newAuthor);
                context.SaveChanges();

                Console.WriteLine($"Auther {FirstName} {LastName} has added with ID: {newAuthor.AuthorId}");
            }
        }
        public void AddBook(string Title, int ISBN, bool IsAvailable, string Rating, int PublishedYear)
        {
            using (Context context = new())
            {
                Book newBook = new Book
                {
                    Title = Title,
                    ISBN = ISBN,
                    IsAvailable = IsAvailable,
                    Rating = Rating,
                    PublishedYear = PublishedYear
                };

                context.Books.Add(newBook);
                context.SaveChanges();

                Console.WriteLine($"The book {Title} has added with ISBN: {newBook.ISBN}");
            }
        }
        public void AddBorrower(string FirstName, string LastName, string LibraryCard, int LibraryCardPin)
        {
            using (Context context = new())
            {
                Borrower newBorrower = new Borrower
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    LibraryCard = LibraryCard,
                    LibraryCardPin = LibraryCardPin
                };

                context.Borrowers.Add(newBorrower);
                context.SaveChanges();

                Console.WriteLine($"Borrower {FirstName} {LastName} has added with Library Card: {newBorrower.LibraryCard}");
            }
        }
        public void BorrowBooks(int bookId, int borrowerId)
        {
            using (Context context = new())
            {
                Book book = context.Books.Find(bookId);
                Borrower borrower = context.Borrowers.Find(borrowerId);

                if (book != null && borrower != null && book.IsAvailable == true)
                {
                    book.IsAvailable = false;
                    book.Borrower = borrower;

                    BookLoan bookLoan = new()
                    {
                        BorrowerId = borrowerId,
                        LoanDate = DateTime.Now,
                        ReturnDate = DateTime.Now,
                    };

                    context.BookLoans.Add(bookLoan);

                    context.SaveChanges();
                }
            }
        }
        public void ReturnBook(int BookId, int BorrowerId)
        {
            using (Context context = new())
            {
                Book bookToReturn = context.Books.Find(BookId);

                if (bookToReturn != null && bookToReturn.Borrower.Id == BorrowerId)
                {
                    // Markera boken som tillgänglig igen
                    bookToReturn.IsAvailable = true;

                    // Nollställ kopplingen till låntagaren
                    bookToReturn.Borrower = null;

                    // Hitta och uppdatera det senaste lånet för boken
                    BookLoan Loan = context.BookLoans
                        .Where(bl => bl.Books.Any(book => book.BookId == BookId) && bl.BorrowerId == BorrowerId)
                        .OrderByDescending(bl => bl.LoanDate)
                        .FirstOrDefault();

                    if (Loan != null)
                    {
                        Loan.ReturnDate = DateTime.Now;
                    }
                    context.SaveChanges();

                    Console.WriteLine($"The book with BookId {BookId} has return back from borrower with ID {BorrowerId}.");
                }
                else
                {
                    Console.WriteLine($"Error: The book with BookId {BookId} is otherwise not lent to borrowers with ID {BorrowerId} or could not be found.");
                }
            }
        }
        public void DeleteBook(int BookId)
        {
            using (Context context = new())
            {
                Book bookToDelete = context.Books.Find(BookId);

                if (bookToDelete != null)
                {
                    // Ta bort själva boken
                    context.Books.Remove(bookToDelete);
                    context.SaveChanges();

                    Console.WriteLine($"Book with BookId {BookId} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Book with BookId {BookId} could not be found.");
                }
            }
        }
        public void DeleteAuthor(int AuthorId)
        {
            using (Context context = new())
            {
                Author authorToDelete = context.Authors.Find(AuthorId);

                if (authorToDelete != null)
                {
                    // Ta bort själva författaren
                    context.Authors.Remove(authorToDelete);
                    context.SaveChanges();

                    Console.WriteLine($"Book with AuthorId {AuthorId} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Book with AuthorId {AuthorId} could not be found.");
                }
            }
        }
        public void DeleteBorrower(int BorrowerId)
        {
            using (Context context = new())
            {
                Borrower borrowerToDelete = context.Borrowers.Find(BorrowerId);

                if (borrowerToDelete != null)
                {
                    // Ta bort själva lånetagaren
                    context.Borrowers.Remove(borrowerToDelete);
                    context.SaveChanges();

                    Console.WriteLine($"Book with BorrowerId {BorrowerId} har tagits bort.");
                }
                else
                {
                    Console.WriteLine($"Book with BorrowerId {BorrowerId} kunde inte hittas.");
                }
            }
        }

    }
}