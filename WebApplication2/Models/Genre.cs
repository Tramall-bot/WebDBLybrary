using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{
    public class Genre
    {
        public long ID { get; set; }
        public string GenName { get; set; }
        public string GenDescription { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
