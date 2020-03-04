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
    public class PagesDao : IPagesDao
    {
        DBConnection _dbConnection = new DBConnection();
        public Page Add(Page page)
        {
            SqlParameter[] parameters =
             {
                new SqlParameter() { ParameterName = "@url", SqlDbType = SqlDbType.NVarChar, Value = page.URL },
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = page.Title },
                new SqlParameter() { ParameterName = "@content", SqlDbType = SqlDbType.NVarChar, Value = page.Content }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddPage", parameters, idParameter);
            page.ID = (int)result;

            return page;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeletePageById", idParameter);
        }

        public IEnumerable<Page> GetAll()
        {
            var pages = new List<Page>();
            Page page = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllPages";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    page = new Page
                    {
                        ID = (int)reader["ID"],
                        URL = reader["URL"] as string,
                        Title = reader["Title"] as string,
                        Content = reader["Content"] as string
                    };

                    pages.Add(page);
                }
            }
            return pages;
        }

        public Page GetById(int id)
        {
            Page page = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetPageById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    page = new Page
                    {
                        ID = id,
                        URL = reader["URL"] as string,
                        Title = reader["Title"] as string,
                        Content = reader["Content"] as string
                    };
                }
            }
            return page;
        }

        public Page Update(Page page)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = page.ID},
                new SqlParameter() { ParameterName = "@url", SqlDbType = SqlDbType.NVarChar, Value = page.URL },
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = page.Title },
                new SqlParameter() { ParameterName = "@content", SqlDbType = SqlDbType.NVarChar, Value = page.Content }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdatePage", parameters);

            return page;
        }
    }
}
