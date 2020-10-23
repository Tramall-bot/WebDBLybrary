using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{

    public class ReturnedBook
    {
        public long ID { get; set; }
        public string RbReturnDate { get; set; }
        public string RbGiveOutDate { get; set; }
        public bool RbReturnFlag { get; set; }
        public long BkId { get; set; }
        public long RdId { get; set; }
        public long EmpId { get; set; }
        public virtual Book Bk { get; set; }
        public virtual Employee Emp { get; set; }
        public Reader Rd { get; set; }
    }
}
