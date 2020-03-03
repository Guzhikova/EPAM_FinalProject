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
    public class PostsDao : IPostsDao
    {
        DBConnection _dbConnection = new DBConnection();
        public Post Add(Post post)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = post.ID }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddPost", parameters, idParameter);
            post.ID = (int)result;

            return post;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeletePostById", idParameter);
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Post Update(Post post)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = post.ID},
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = post.ID }
            };
           
            object result = _dbConnection.ExecuteStoredProcedure("dbo.UpdatePost", parameters);

            return post;
        }
    }
}
