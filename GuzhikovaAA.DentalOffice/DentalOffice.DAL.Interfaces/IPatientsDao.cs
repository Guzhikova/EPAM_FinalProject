using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IPatientsDao
    {
        IEnumerable<Patient> GetAll();

        Patient GetById(int id);

        Patient Add(Patient patient);

        void DeleteById(int id);

        Patient Update(Patient patient);
    }
}
