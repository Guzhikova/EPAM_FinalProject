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
    internal class PageFileDao
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

        public void UpdateFilesForPage(Page page)
        {
            var oldFiles = GetAllFilesByPageId(page.ID);
            var newFiles = page.Files;

            var filesToDelete = oldFiles.Where(n => !newFiles.Any(t => t.ID == n.ID));
            foreach (var file in filesToDelete)
            {
                DeleteFileForPage(page.ID, file.ID);
            }

            var filesToAdd = newFiles.Where(n => !oldFiles.Any(t => t.ID == n.ID));
            foreach (var file in filesToAdd)
            {
                AddFileForPage(page.ID, file.ID);
            }
        }
    }
}
