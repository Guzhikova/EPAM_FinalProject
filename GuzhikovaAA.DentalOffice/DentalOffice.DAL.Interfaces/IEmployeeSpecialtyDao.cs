using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IEmployeeSpecialtyDao
    {

        //The interface for work with the relationship table 'employee_specialty' consisting only employee ID and specialty ID

        IEnumerable<Specialty> GetAllSpecialtiesByEmployeeId(int id);

        void AddSpecialtyForEmployee(int employeeId, int specialtyId);

        void DeleteSpecialtyForEmployee(int employeeId, int specialtyId);
    }
}
