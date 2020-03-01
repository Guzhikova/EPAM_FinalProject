using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    public class EmployeeFileDao : IEmployeeFileDao
    {
        public void AddFileForEmployee(int employeeId, int fileId)
        {
            throw new NotImplementedException();
        }

        public void DeleteFileForEmployee(int employeeId, int fileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAllFilesByEmployeeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
