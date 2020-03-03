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
    public class NewsDao : INewsDao
    {
        DBConnection _dbConnection = new DBConnection();
        public News Add(News news)
        {
            SqlParameter[] parameters =
              {
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = news.Title },
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = news.Date },
                new SqlParameter() { ParameterName = "@content", SqlDbType = SqlDbType.NVarChar, Value = news.Content },
                new SqlParameter() { ParameterName = "@author", SqlDbType = SqlDbType.Int, Value = news.Author.ID }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddNews", parameters, idParameter);
            news.ID = (int)result;

            return news;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteNewsById", idParameter);
        }

        public IEnumerable<News> GetAll()
        {
            throw new NotImplementedException();
        }

        public News GetById(int id)
        {
            throw new NotImplementedException();
        }

        public News Update(News news)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = news.ID},
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = news.Title },
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = news.Date },
                new SqlParameter() { ParameterName = "@content", SqlDbType = SqlDbType.NVarChar, Value = news.Content },
                new SqlParameter() { ParameterName = "@author", SqlDbType = SqlDbType.Int, Value = news.Author.ID }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdateNews", parameters);

            return news;
        }
    }
}
