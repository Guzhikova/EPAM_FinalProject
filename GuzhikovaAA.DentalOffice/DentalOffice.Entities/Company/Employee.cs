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
        public List<Specialty> Specialties { get; set; }

        public int Age
        {
            get => GetCurrentInterval(DateOfBirth);
        }        

       public int WorkExperience
        {
            get => GetCurrentInterval(DateOfEmployement);
        }

        private int GetCurrentInterval(DateTime date)
        {
            DateTime today = DateTime.Today;
            int interval = default(int);            

            if (date != default(DateTime))
            {
                interval = today.Year - date.Year;

                if (date > today.AddYears(-interval))
                {
                    interval--;
                }
            }
            return interval;
        }
    }
}
