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
            var roles = new List<Role>();
            Role role = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllRoles";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    role = new Role
                    {
                        ID = (int)reader["ID"],
                        Title = reader["Title"] as string
                    };
                    roles.Add(role);
                }
            }

            // return roles.Count() > 0 ? roles : null;
            return roles;
        }

        public Role GetById(int id)
        {
            Role role = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetRoleById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    role = new Role
                    {
                        ID = id,
                        Title = reader["Title"] as string
                    };
                }
            }
            return role;
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

        public void Update(Role role)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = role.ID},
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = role.Title }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddRole", parameters);

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
