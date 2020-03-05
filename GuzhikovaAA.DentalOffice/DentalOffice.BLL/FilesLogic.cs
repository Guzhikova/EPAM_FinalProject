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
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetAll()
        {
            throw new NotImplementedException();
        }

        public File GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(File file)
        {
            throw new NotImplementedException();
        }
    }
}
