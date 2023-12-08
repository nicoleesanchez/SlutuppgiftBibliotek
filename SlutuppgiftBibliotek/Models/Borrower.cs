using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutuppgiftBibliotek.Models
{
    internal class Borrower
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LibraryCard { get; set; }
        public int LibraryCardPin { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

        public Borrower() 
        {
        
        }
    }
}
