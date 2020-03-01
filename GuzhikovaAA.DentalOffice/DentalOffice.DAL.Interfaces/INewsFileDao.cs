using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface INewsFileDao
    {
        //The interface for work with the relationship table 'news_file' consisting only news ID and file ID

        IEnumerable<File> GetAllFilesByNewsId(int id);

        void AddFileForNews(int newsId, int fileId);

        void DeleteFileForNews(int newsId, int fileId);
    }
}
