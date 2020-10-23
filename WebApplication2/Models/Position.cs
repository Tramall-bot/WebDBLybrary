using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{
    public class Position
    {
        public long ID { get; set; }
        public string PosName { get; set; }
        public long PosSalary { get; set; }
        public string PosDuties { get; set; }
        public string PosRequirements { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
