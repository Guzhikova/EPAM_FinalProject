using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IPageFileDao
    {
        //The interface for work with the relationship table 'page_file' consisting only page ID and file ID

        IEnumerable<File> GetAllFilesByPageId(int id);

        void AddFileForPage(int pageId, int fileId);

        void DeleteFileForPage(int pageId, int fileId);
    }
}
