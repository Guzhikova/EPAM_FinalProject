using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL.Interfaces
{
    public interface IPatientsLogic
    {
        IEnumerable<Patient> GetAll();

        Patient GetById(int id);

        Patient Add(Patient patient);

        void DeleteById(int id);

        void Update(Patient patient);
    }
}
