using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Employee
    {
        public long ID { get; set; }
        [Display(Name = "Полное имя рабочего")]
        public string EmpFullName { get; set; }
        [Display(Name = "Возвраст рабочего")]
        public long EmpAge { get; set; }
        [Display(Name = "Пол рабочего")]
        public string EmpSex { get; set; }
        [Display(Name = "Адрес рабочего")]
        public string EmpAddress { get; set; }
        [Display(Name = "Телефон рабочего")]
        public string EmpPhoneNumber { get; set; }
        [Display(Name = "Паспортное данные рабочего")]
        public string EmpPassportData { get; set; }
        [Display(Name = "Позиция рабочего")]
        public long? PosID { get; set; }
        [Display(Name = "Книги, возвращённые рабочего")]
        public virtual ICollection<ReturnedBook> ReturnedBooks { get; set; }
        [Display(Name = "Позиция рабочего")]
        public virtual Position Pos { get; set; }
    }
}
