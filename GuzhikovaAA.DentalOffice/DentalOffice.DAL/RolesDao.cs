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
   
    public class RolesDao : IRolesDao
    { 
        DBConnection _dbConnection = new DBConnection();
        public IEnumerable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Role Add(Role role)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = role.Title }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddRole", parameters, idParameter);
            role.ID = (int)result;

            return role;
        }

        public Role Update(Role role)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = role.ID},
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = role.Title }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddRole", parameters);

            return role;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteRoleById", idParameter);
        }
    }
}
