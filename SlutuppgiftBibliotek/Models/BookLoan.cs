using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutuppgiftBibliotek.Models
{
    internal class BookLoan
    {
        public int Id { get; set; } 
        public DateTime? ReturnDate { get; set; }   
        public Book Book { get; set; }
        public Borrower Borrower { get; set; }
        public ICollection<Borrower>Borrowers { get; set; } = new List<Borrower>();
        public BookLoan() 
        {
        
        }
    }
}
