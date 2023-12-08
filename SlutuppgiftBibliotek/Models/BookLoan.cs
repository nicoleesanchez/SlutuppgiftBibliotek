using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutuppgiftBibliotek.Models
{
    internal class BookLoan
    {
        public int BookLoanId { get; set; } 
        public int BorrowerId { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? ReturnDate
        {
            get
            {
                return LoanDate?.AddDays(14);

            }
            set
            {
                LoanDate = value;
            }
        }
        public ICollection<Book> Books { get; set; }= new List<Book>();
        public Borrower Borrowers { get; set; }
        public BookLoan() 
        {
        
        }
    }
}
