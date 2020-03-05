using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL.Interfaces
{

    public interface IUsersLogic
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        User Add(User user);

        void DeleteById(int id);

        void Update(User user);

        User GetByLogin(string login);
        bool isPairLoginPassword(string login, string password);
    }

}
