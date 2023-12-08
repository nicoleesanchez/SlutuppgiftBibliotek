using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutuppgiftBibliotek.Models
{
    internal class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int PublishedYear { get; set; }
        public string Rating { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Borrower? Borrower { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public Book() 
        {
        
        }
    }
}
