using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Entities
{
    public class Record
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Patient Patient { get; set; }
        public Employee Employee { get; set; }
        public string Comment { get; set; }
    }
}
