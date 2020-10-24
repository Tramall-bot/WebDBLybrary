using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{
    public class Position
    {
        public long ID { get; set; }
        [Display(Name = "Название позиции")] 
        public string PosName { get; set; }
        [Display(Name = "Зарплата позиции")] 
        public long PosSalary { get; set; }
        [Display(Name = "Обязанности позиции")] 
        public string PosDuties { get; set; }
        [Display(Name = "Требования позиции")] 
        public string PosRequirements { get; set; }

        [Display(Name = "Рабочии этой позиции")] 
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
