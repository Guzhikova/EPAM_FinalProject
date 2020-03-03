using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
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
    
                var idParameter = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@id",
                    Direction = System.Data.ParameterDirection.Output
                };

               /////....................

            SqlParameter[] parameters =
            {
               //........................
            };

            user.ID = (int)_dbConnection.ExecuteStoredProcedure("dbo.AddUser", parameters, idParameter);

            return user;
            
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
                Direction = System.Data.ParameterDirection.Input
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

            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Direction = System.Data.ParameterDirection.Output
            };

            /////....................

            SqlParameter[] parameters =
            {
               //........................
            };


            _dbConnection.ExecuteStoredProcedure("dbo.UpdateUser", parameters);
            
            return user;
        }
    }
}
