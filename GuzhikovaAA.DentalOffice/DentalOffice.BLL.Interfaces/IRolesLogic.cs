using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL.Interfaces
{
    public interface IRolesLogic
    {
        IEnumerable<Role> GetAll();

        Role GetById(int id);

        Role Add(Role role);

        void Update(Role role);

        void DeleteById(int id);
    }
}
