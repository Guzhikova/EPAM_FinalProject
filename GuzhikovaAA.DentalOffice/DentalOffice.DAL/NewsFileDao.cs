using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    public class NewsFileDao : INewsFileDao
    {
        public void AddFileForNews(int newsId, int fileId)
        {
            throw new NotImplementedException();
        }

        public void DeleteFileForNews(int newsId, int fileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAllFilesByNewsId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
