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
    public class NewsFileDao : INewsFileDao
    {
        DBConnection _dbConnection = new DBConnection();
        public void AddFileForNews(int newsId, int fileId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@newsID", SqlDbType = SqlDbType.Int, Value = newsId },
                new SqlParameter() { ParameterName = "@fileID", SqlDbType = SqlDbType.Int, Value = fileId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddFileForNews", parameters);
        }

        public void DeleteFileForNews(int newsId, int fileId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@newsID", SqlDbType = SqlDbType.Int, Value = newsId },
                new SqlParameter() { ParameterName = "@fileID", SqlDbType = SqlDbType.Int, Value = fileId }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteFileForNews", parameters);
        }

        public IEnumerable<File> GetAllFilesByNewsId(int id)
        {
            return _dbConnection.GetAllFilesByEntityId("GetAllFilesByNewsId", id);
        }
    }
}
