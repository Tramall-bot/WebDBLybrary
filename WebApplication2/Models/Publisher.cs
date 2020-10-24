using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{
    public class Publisher
    {
        public long ID { get; set; }
        [Display(Name = "Имя издателя")] 
        public string PubName { get; set; }
        [Display(Name = "Город издателя")] 
        public string PubCity { get; set; }
        [Display(Name = "Адрес издателя")] 
        public string PubAddress { get; set; }

        [Display(Name = "Книги этого издателя")] 
        public virtual ICollection<Book> Books { get; set; }
    }
}
