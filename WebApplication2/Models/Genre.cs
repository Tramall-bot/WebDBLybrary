using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Genre
    {
        public long ID { get; set; }
        [Display(Name = "Название жанра")] 
        public string GenName { get; set; }
        [Display(Name = "Описание жанра")] 
        public string GenDescription { get; set; }

        [Display(Name = "Книги этого жанра")] 
        public virtual ICollection<Book> Books { get; set; }
    }
}
