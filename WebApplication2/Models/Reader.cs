using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Reader
    {
        public long ID { get; set; }
        [Display(Name = "Имя читателя")] 
        public string RdFullName { get; set; }
        [Display(Name = "День рождения читателя")] 
        public DateTime RdBdDate { get; set; }
        [Display(Name = "Пол читателя")] 
        public string RdSex { get; set; }
        [Display(Name = "Адрес читателя")] 
        public string RdAddress { get; set; }
        [Display(Name = "Телефон читателя")] 
        public string RdPhoneNumber { get; set; }
        [Display(Name = "Паспортные данные читателя")] 
        public string RdPassportData { get; set; }

        [Display(Name = "Возвращённые книги этого читателя")] 
        public ICollection<ReturnedBook> ReturnedBooks { get; set; }
    }
}
