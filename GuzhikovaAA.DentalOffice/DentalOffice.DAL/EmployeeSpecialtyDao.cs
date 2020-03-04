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
            var specialties = new List<Specialty>();
            Specialty specialty = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllSpecialtiesByEmployeeId";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    specialty = new Specialty
                    {
                        ID = id,
                        Title = reader["Title"] as string,
                        Category = reader["Category"] as string
                    };
                    specialties.Add(specialty);
                }
            }
            return specialties;
        }
    }
}
