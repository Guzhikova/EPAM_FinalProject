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

    public class UserRoleDao : IUserRoleDao
    {
        DBConnection _dbConnection = new DBConnection();
        public void AddRoleForUser(int userId, int roleId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@userID", SqlDbType = SqlDbType.Int, Value = userId },
                new SqlParameter() { ParameterName = "@roleID", SqlDbType = SqlDbType.Int, Value = roleId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddRoleForUser", parameters);
        }

        public void DeleteRoleForUser(int userId, int roleId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@userID", SqlDbType = SqlDbType.Int, Value = userId },
                new SqlParameter() { ParameterName = "@roleID", SqlDbType = SqlDbType.Int, Value = roleId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteRoleForUser", parameters);
        }

        public IEnumerable<Role> GetAllRolesByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
