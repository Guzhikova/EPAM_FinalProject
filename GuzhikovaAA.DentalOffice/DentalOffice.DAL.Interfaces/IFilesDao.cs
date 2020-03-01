using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IFilesDao
    {
        IEnumerable<File> GetAll();

        File GetById(int id);

        File Add(File file);

        File Update(File file);

        void DeleteById(int id);
    }
}
