using Microsoft.EntityFrameworkCore;
using SlutuppgiftBibliotek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutuppgiftBibliotek.Data
{
    internal class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost; Database= NewtonLibraryNicole; Trusted_Connection=True; Trust Server Certificate =Yes; User Id= NewtonLibrary; password= NewtonLibrary");
        }
    }
}
