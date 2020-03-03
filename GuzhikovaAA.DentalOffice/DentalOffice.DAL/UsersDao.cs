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
    public class UsersDao : IUsersDao
    {
        DBConnection _dbConnection = new DBConnection();

        public User Add(User user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@login", SqlDbType = SqlDbType.NVarChar, Value = user.Login },
                new SqlParameter() { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = user.Password },
                new SqlParameter() { ParameterName = "@email", SqlDbType = SqlDbType.NVarChar, Value = user.Email },
                new SqlParameter() { ParameterName = "@registrationDate", SqlDbType = SqlDbType.DateTime2, Value = user.RegistrationDate },
                new SqlParameter() { ParameterName = "@photo", SqlDbType = SqlDbType.VarBinary, Value = user.Photo },
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = user.EmployeeData.ID },
                new SqlParameter() { ParameterName = "@patientID", SqlDbType = SqlDbType.Int, Value = user.PatientData.ID },
            };

            SqlParameter idParameter = 
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddUser", parameters, idParameter);
            user.ID = (int)result;

            return user;            
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteUserById", idParameter);
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User user)
        {
            SqlParameter[] parameters =
           {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = user.ID},
                new SqlParameter() { ParameterName = "@login", SqlDbType = SqlDbType.NVarChar, Value = user.Login },
                new SqlParameter() { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = user.Password },
                new SqlParameter() { ParameterName = "@email", SqlDbType = SqlDbType.NVarChar, Value = user.Email },
                new SqlParameter() { ParameterName = "@registrationDate", SqlDbType = SqlDbType.DateTime2, Value = user.RegistrationDate },
                new SqlParameter() { ParameterName = "@photo", SqlDbType = SqlDbType.VarBinary, Value = user.Photo },
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = user.EmployeeData.ID },
                new SqlParameter() { ParameterName = "@patientID", SqlDbType = SqlDbType.Int, Value = user.PatientData.ID }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddUser", parameters);

            return user;            
        }
    }
}
