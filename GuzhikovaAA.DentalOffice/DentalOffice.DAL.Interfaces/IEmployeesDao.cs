using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IEmployeesDao
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        Employee Add(Employee employee);

        Employee Update(Employee employee);

        void DeleteById(int id);

    }
}
