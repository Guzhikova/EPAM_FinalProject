using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IPagesDao
    {
        IEnumerable<Page> GetAll();

        Page GetById(int id);

        Page Add(Page page);

        void DeleteById(int id);

        Page Update(Page page);
    }
}
