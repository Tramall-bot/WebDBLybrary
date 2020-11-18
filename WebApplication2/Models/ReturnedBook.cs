using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{

    public class ReturnedBook
    {
        public long ID { get; set; }
        [Display(Name = "Дата возвращения книги")] 
        public DateTime RbReturnDate { get; set; }
        [Display(Name = "Дата выдачи книги")] 
        public DateTime RbGiveOutDate { get; set; }
        [Display(Name = "Отметка о возврате")] 
        public bool RbReturnFlag { get; set; }
        [Display(Name = "Книга")] 
        public long BkId { get; set; }
        [Display(Name = "Читатель")] 
        public long RdId { get; set; }
        [Display(Name = "Рабочий")] 
        public long EmpId { get; set; }
        [Display(Name = "Книга")] 
        public virtual Book Bk { get; set; }
        [Display(Name = "Рабочий")] 
        public virtual Employee Emp { get; set; }
        [Display(Name = "Читатель")] 
        public Reader Rd { get; set; }
    }
}
