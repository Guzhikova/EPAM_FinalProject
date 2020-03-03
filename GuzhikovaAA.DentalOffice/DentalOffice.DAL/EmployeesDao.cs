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
    public class EmployeesDao : IEmployeesDao
    {
        DBConnection _dbConnection = new DBConnection();
        public Employee Add(Employee employee)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = employee.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = employee.FirstName },
                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar, Value = employee.MiddleName },
                new SqlParameter() { ParameterName = "@dateOfBirth", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfBirth },
                new SqlParameter() { ParameterName = "@dateOfEmployment", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfEmployement },
                new SqlParameter() { ParameterName = "@note", SqlDbType = SqlDbType.NVarChar, Value = employee.Note },
                new SqlParameter() { ParameterName = "@postID", SqlDbType = SqlDbType.Int, Value = employee.Post }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddEmployee", parameters, idParameter);
            employee.ID = (int)result;

            return employee;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteEmployeeById", idParameter);
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employee)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = employee.ID},
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = employee.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = employee.FirstName },
                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar, Value = employee.MiddleName },
                new SqlParameter() { ParameterName = "@dateOfBirth", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfBirth },
                new SqlParameter() { ParameterName = "@dateOfEmployment", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfEmployement },
                new SqlParameter() { ParameterName = "@note", SqlDbType = SqlDbType.NVarChar, Value = employee.Note },
                new SqlParameter() { ParameterName = "@postID", SqlDbType = SqlDbType.Int, Value = employee.Post }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdateEmployee", parameters);

            return employee;
        }
    }
}
