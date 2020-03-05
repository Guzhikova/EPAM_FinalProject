using DentalOffice.BLL.Interfaces;
using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL
{
    public class SpecialtiesLogic : ISpecialtiesLogic
    {
        private readonly IUsersDao _specialtiesDao;

        public SpecialtiesLogic(IUsersDao specialtiesDao)
        {
            _specialtiesDao = specialtiesDao;
        }
        public Specialty Add(Specialty specialty)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Specialty> GetAll()
        {
            throw new NotImplementedException();
        }

        public Specialty GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Specialty specialty)
        {
            throw new NotImplementedException();
        }
    }
}
