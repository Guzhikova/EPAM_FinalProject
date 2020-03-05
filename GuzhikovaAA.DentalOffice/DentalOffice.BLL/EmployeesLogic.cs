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
    public class EmployeesLogic : IEmployeesLogic
    {
        private readonly IEmployeesDao _employeesDao;

        public EmployeesLogic(IEmployeesDao employeesDao)
        {
            _employeesDao = employeesDao;
        }

        public Employee Add(Employee employee)
        {
            return _employeesDao.Add(employee);
        }

        public void DeleteById(int id)
        {
            _employeesDao.DeleteById(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeesDao.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeesDao.GetById(id);
        }

        public void Update(Employee employee)
        {
            _employeesDao.Update(employee);
        }
    }
}
