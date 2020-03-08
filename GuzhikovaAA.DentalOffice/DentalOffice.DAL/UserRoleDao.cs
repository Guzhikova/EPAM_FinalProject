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

    internal class UserRoleDao
    {
        DBConnection _dbConnection = new DBConnection();
        public void AddRoleForUser(int userId, int roleId)
        {  try
            {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@userID", SqlDbType = SqlDbType.Int, Value = userId },
                new SqlParameter() { ParameterName = "@roleID", SqlDbType = SqlDbType.Int, Value = roleId }
            };

          
                _dbConnection.ExecuteStoredProcedure("dbo.AddRoleForUser", parameters);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException($"Error! Trying to add nonexistent ID for user or role to the 'user_role' table of database: {ex.Message}", ex); ;
            }
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
            var roles = new List<Role>();
            Role role = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllRolesByUserId";

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
                    roles.Add(role);
                }
            }
            return roles;
        }

        public void UpdateRolesForUser(User user)
        {
            if (user.Roles != null)
            {
                var oldRoles = GetAllRolesByUserId(user.ID);
                var newRoles = user.Roles;

                var rolesToDelete = oldRoles.Where(n => !newRoles.Any(t => t.ID == n.ID));
                foreach (var role in rolesToDelete)
                {
                    DeleteRoleForUser(user.ID, role.ID);
                }

                var rolesToAdd = newRoles.Where(n => !oldRoles.Any(t => t.ID == n.ID));
                foreach (var role in rolesToAdd)
                {
                    if (role == null)
                        throw new NullReferenceException($"Error! User roles cannot be created/updated because requested role does not exist in database!"); 

                    AddRoleForUser(user.ID, role.ID);
                    
                }
            }

        }
    }
}
