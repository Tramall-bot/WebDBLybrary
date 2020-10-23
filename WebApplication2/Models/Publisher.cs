using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{
    public class Publisher
    {
        public long ID { get; set; }
        public string PubName { get; set; }
        public string PubCity { get; set; }
        public string PubAddress { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
