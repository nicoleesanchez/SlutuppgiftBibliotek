using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutuppgiftBibliotek.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public string Rating { get; set; }
        public bool IsAvailable { get; set; } = true;
        public ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>();
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public Book() 
        {
        
        }
    }
}
