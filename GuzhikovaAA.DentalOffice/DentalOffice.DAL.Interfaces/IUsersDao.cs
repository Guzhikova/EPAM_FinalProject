using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IUsersDao
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        User Add(User user);

        void DeleteById(int id);

        void Update(User user);
        IEnumerable<User> GetAllByRoleId(int id);
    }
}
