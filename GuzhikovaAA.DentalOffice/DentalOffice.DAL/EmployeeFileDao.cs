using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    internal class EmployeeFileDao
    {
        DBConnection _dbConnection = new DBConnection();
        public void AddFileForEmployee(int employeeId, int fileId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = employeeId },
                new SqlParameter() { ParameterName = "@fileID", SqlDbType = SqlDbType.Int, Value = fileId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddFileForEmployeee", parameters);
        }

        public void DeleteFileForEmployee(int employeeId, int fileId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = employeeId },
                new SqlParameter() { ParameterName = "@fileID", SqlDbType = SqlDbType.Int, Value = fileId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteFileForEmployee", parameters);
        }

        public IEnumerable<File> GetAllFilesByEmployeeId(int id)
        {
            return _dbConnection.GetAllFilesByEntityId("GetAllFilesByEmployeeId", id);
        }

        public void UpdateFilesForEmployee(Employee employee)
        {
            var oldFiles = GetAllFilesByEmployeeId(employee.ID);
            var newFiles = employee.Files;

            var filesToDelete = oldFiles.Where(n => !newFiles.Any(t => t.ID == n.ID));
            foreach (var file in filesToDelete)
            {
                DeleteFileForEmployee(employee.ID, file.ID);
            }

            var filesToAdd = newFiles.Where(n => !oldFiles.Any(t => t.ID == n.ID));
            foreach (var file in filesToAdd)
            {
                AddFileForEmployee(employee.ID, file.ID);
            }
        }
    }
}
