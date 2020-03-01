using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IEmployeeFileDao
    {
        //The interface for work with the relationship table 'employee_file' consisting only employee ID and file ID

        IEnumerable<File> GetAllFilesByEmployeeId(int id);

        void AddFileForEmployee(int employeeId, int fileId);

        void DeleteFileForEmployee(int employeeId, int fileId);
    }
}
