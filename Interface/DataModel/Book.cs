using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.DataModel
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public byte[] image { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

    }
}
