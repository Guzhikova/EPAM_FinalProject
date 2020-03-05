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
        private readonly ISpecialtiesDao _specialtiesDao;

        public SpecialtiesLogic(ISpecialtiesDao specialtiesDao)
        {
            _specialtiesDao = specialtiesDao;
        }
        public Specialty Add(Specialty specialty)
        {
            return _specialtiesDao.Add(specialty);
        }

        public void DeleteById(int id)
        {
            _specialtiesDao.DeleteById(id);
        }

        public IEnumerable<Specialty> GetAll()
        {
            return _specialtiesDao.GetAll();
        }

        public Specialty GetById(int id)
        {
            return _specialtiesDao.GetById(id);
        }

        public void Update(Specialty specialty)
        {
            _specialtiesDao.Update(specialty);        
        }
    }
}
