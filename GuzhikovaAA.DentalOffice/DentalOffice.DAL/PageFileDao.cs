using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    public class PageFileDao : IPageFileDao
    {
        public void AddFileForPage(int pageId, int fileId)
        {
            throw new NotImplementedException();
        }

        public void DeleteFileForPage(int pageId, int fileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAllFilesByPageId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
