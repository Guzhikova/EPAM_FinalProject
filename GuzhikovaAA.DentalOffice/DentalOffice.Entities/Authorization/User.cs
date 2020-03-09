using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password  { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public byte[] Photo { get; set; }

        public Employee EmployeeData { get; set; }
        public Patient PatientData { get; set; }

        public List<Role> Roles { get; set; }      

    }
}
