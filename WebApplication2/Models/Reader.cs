using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDBLybrary.Models
{
    public class Reader
    {
        public long ID { get; set; }
        public string RdFullName { get; set; }
        public string RdBdDate { get; set; }
        public string RdSex { get; set; }
        public string RdAddress { get; set; }
        public string RdPhoneNumber { get; set; }
        public string RdPassportData { get; set; }

        public ICollection<ReturnedBook> ReturnedBooks { get; set; }
    }
}
