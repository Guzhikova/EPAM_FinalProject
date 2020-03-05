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
    internal class NewsFileDao
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

        public void UpdateFilesForNews(News news)
        {
            var oldFiles = GetAllFilesByNewsId(news.ID);
            var newFiles = news.Files;

            var filesToDelete = oldFiles.Where(n => !newFiles.Any(t => t.ID == n.ID));
            foreach (var file in filesToDelete)
            {
                DeleteFileForNews(news.ID, file.ID);
            }

            var filesToAdd = newFiles.Where(n => !oldFiles.Any(t => t.ID == n.ID));
            foreach (var file in filesToAdd)
            {
                AddFileForNews(news.ID, file.ID);
            }
        }
    }
}
