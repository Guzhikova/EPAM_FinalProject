using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL.Interfaces
{
    public interface IPagesLogic
    {
        IEnumerable<Page> GetAll();

        Page GetById(int id);

        Page Add(Page page);

        void DeleteById(int id);

        void Update(Page page);
    }
}
