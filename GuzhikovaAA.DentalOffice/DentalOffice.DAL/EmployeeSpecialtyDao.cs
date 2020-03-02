using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    public class EmployeeSpecialtyDao : IEmployeeSpecialtyDao
    {
        public void AddSpecialtyForEmployee(int employeeId, int specialtyId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpecialtyForEmployee(int employeeId, int specialtyId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Specialty> GetAllSpecialtiesByEmployeeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
