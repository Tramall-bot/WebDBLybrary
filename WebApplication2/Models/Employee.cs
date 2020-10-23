using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{
    public class Employee
    {
        public long ID { get; set; }
        public string EmpFullName { get; set; }
        public long EmpAge { get; set; }
        public string EmpSex { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPhoneNumber { get; set; }
        public string EmpPassportData { get; set; }

        public virtual ICollection<ReturnedBook> ReturnedBooks { get; set; }
        public virtual Position Pos { get; set; }
    }
}
