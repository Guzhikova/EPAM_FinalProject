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
    public class EmployeeSpecialtyDao : IEmployeeSpecialtyDao
    {
        DBConnection _dbConnection = new DBConnection();
        public void AddSpecialtyForEmployee(int employeeId, int specialtyId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = employeeId },
                new SqlParameter() { ParameterName = "@specialtyID", SqlDbType = SqlDbType.Int, Value = specialtyId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddSpecialtyForEmployee", parameters);
        }

        public void DeleteSpecialtyForEmployee(int employeeId, int specialtyId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = employeeId },
                new SqlParameter() { ParameterName = "@specialtyID", SqlDbType = SqlDbType.Int, Value = specialtyId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteSpecialtyForEmployee", parameters);
        }

        public IEnumerable<Specialty> GetAllSpecialtiesByEmployeeId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
