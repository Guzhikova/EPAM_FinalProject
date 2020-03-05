using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL.Interfaces
{
    public interface IFilesLogic
    {
        IEnumerable<File> GetAll();

        File GetById(int id);

        File Add(File file);

        void Update(File file);

        void DeleteById(int id);
    }
}
