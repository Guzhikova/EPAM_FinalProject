using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface ISpecialtiesDao
    {
        IEnumerable<Specialty> GetAll();

        Specialty GetById(int id);

        Specialty Add(Specialty specialty);

        void DeleteById(int id);

        Specialty Update(Specialty specialty);
    }
}
