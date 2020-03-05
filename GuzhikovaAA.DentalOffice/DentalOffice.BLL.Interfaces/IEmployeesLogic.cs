using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL.Interfaces
{
    public interface IEmployeesLogic
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(int id);

        Employee Add(Employee employee);

        void Update(Employee employee);

        void DeleteById(int id);
    }
}
