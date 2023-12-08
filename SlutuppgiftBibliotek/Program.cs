using SlutuppgiftBibliotek.Data;
using Helpers;
using SlutuppgiftBibliotek.Models;

namespace SlutuppgiftBibliotek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.Seed();
            dataAccess.BorrowBooks(2, 3);
            dataAccess.DeleteBook(4);
            dataAccess.DeleteAuthor(8);
            dataAccess.DeleteBorrower(5);
            dataAccess.AddAuthor("Astrid", "Lindgren");
            dataAccess.AddBook("Pippi", 123456789, true, "Great Book", 2010);
            dataAccess.AddBorrower("Nicole", "Sanchez", "MY004", 1234);
            dataAccess.ReturnBook(123456789, 1);

        }
    }
}