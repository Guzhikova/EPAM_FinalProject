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
    public class PageFileDao : IPageFileDao
    {
        DBConnection _dbConnection = new DBConnection();
        public void AddFileForPage(int pageId, int fileId)
        {
            SqlParameter[] parameters =
           {
                new SqlParameter() { ParameterName = "@pageID", SqlDbType = SqlDbType.Int, Value =  pageId },
                new SqlParameter() { ParameterName = "@fileID", SqlDbType = SqlDbType.Int, Value = fileId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddFileForPage", parameters);
        }

        public void DeleteFileForPage(int pageId, int fileId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@pageID", SqlDbType = SqlDbType.Int, Value =  pageId },
                new SqlParameter() { ParameterName = "@fileID", SqlDbType = SqlDbType.Int, Value = fileId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteFileForPage", parameters);
        }

        public IEnumerable<File> GetAllFilesByPageId(int id)
        {
           return _dbConnection.GetAllFilesByEntityId("GetAllFilesByPageId", id);
        }
    }
}
