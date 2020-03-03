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
            throw new NotImplementedException();
        }

        public Page GetById(int id)
        {
            throw new NotImplementedException();
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
