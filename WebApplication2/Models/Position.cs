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
        [Display(Name = "Название должности")] 
        public string PosName { get; set; }
        [Display(Name = "Зарплата должности")] 
        public long PosSalary { get; set; }
        [Display(Name = "Обязанности должности")] 
        public string PosDuties { get; set; }
        [Display(Name = "Требования должности")] 
        public string PosRequirements { get; set; }

        [Display(Name = "Рабочии этой должности")] 
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
