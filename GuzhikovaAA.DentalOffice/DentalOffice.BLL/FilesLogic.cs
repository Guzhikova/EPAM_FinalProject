using DentalOffice.BLL.Interfaces;
using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL
{
    public class FilesLogic : IFilesLogic
    {
        private readonly IFilesDao _filesDao;

        public FilesLogic(IFilesDao filesDao)
        {
            _filesDao = filesDao;
        }

        public File Add(File file)
        {
            return _filesDao.Add(file);
        }

        public void DeleteById(int id)
        {
            _filesDao.DeleteById(id);
        }

        public IEnumerable<File> GetAll()
        {
            return _filesDao.GetAll();
        }

        public File GetById(int id)
        {
            return _filesDao.GetById(id);
        }

        public void Update(File file)
        {
            _filesDao.Update(file); 
        }
    }
}
