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
            var newsList = new List<News>();
            News news = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllNews";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    news = new News
                    {
                        ID = (int)reader["ID"],
                        Title = reader["Title"] as string,
                        Date = (reader["Date"] != DBNull.Value)
                            ? (DateTime)reader["Date"]
                            : default(DateTime),
                        Content = reader["Content"] as string
                    };

                    if (reader["Author"] != DBNull.Value)
                    {
                        news.Author = new User
                        {
                            ID = (int)reader["Author"]
                        };
                    }
                    newsList.Add(news);
                }
            }
            return newsList;
        }

        public News GetById(int id)
        {
            News news = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetNewsById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    news = new News
                    {
                        ID = id,
                        Title = reader["Title"] as string,
                        Date = (reader["Date"] != DBNull.Value)
                            ? (DateTime)reader["Date"]
                            : default(DateTime),
                        Content = reader["Content"] as string
                    };

                    if (reader["Author"] != DBNull.Value)
                    {
                        news.Author = new User
                        {
                            ID = (int)reader["Author"]
                        };
                    }
                }
            }
            return news;
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
