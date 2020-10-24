using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace WebDBLybrary.Models
{
    public class Book
    {
        [Display (Name = "Код книги")]
        public long ID { get; set; }
        [Display(Name = "Название книги")]
        public string BkName { get; set; }
        [Display(Name = "Имя автора")]
        public string BkAuthor { get; set; }
        [Display(Name = "Дата выпуска книги")]
        public DateTime BkRealiseDate { get; set; }
        [Display(Name = "Код Издателя")]
        public long? PublisherID { get; set; }
        [Display(Name = "Код жанра")]
        public long? GenreId { get; set; }
        [Display(Name = "Возвражение книги")]
        public ICollection<ReturnedBook> ReturnedBooks { get; set; }
        [Display(Name = "Жанр книги")]
        public virtual Genre Gen { get; set; }
        [Display(Name = "Издатель книги")]
        public virtual Publisher Pub { get; set; }
    }
}
