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
    public class PatientsLogic : IPatientsLogic
    {
        private readonly IPatientsDao _patientsDao;

        public PatientsLogic(IPatientsDao patientsDao)
        {
            _patientsDao = patientsDao;
        }

        public Patient Add(Patient patient)
        {
            return _patientsDao.Add(patient);
        }

        public void DeleteById(int id)
        {
            _patientsDao.DeleteById(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientsDao.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientsDao.GetById(id);
        }

        public void Update(Patient patient)
        {
            _patientsDao.Update(patient);
        }
    }
}
