using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IRolesDao
    {
        IEnumerable<Role> GetAll();

        Role GetById(int id);

        Role Add(Role role);

        Role Update(Role role);

        void DeleteById(int id);

    }
}
