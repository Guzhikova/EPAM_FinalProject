using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Entities
{
    public class Employee
    {
        public int ID { get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployement { get; set; }
        public string Note { get; set; }
        public Post Post { get; set; }

        public List<File> Files { get; set; }
    }
}
