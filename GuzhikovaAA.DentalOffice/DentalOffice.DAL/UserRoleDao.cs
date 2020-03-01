using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    public class UserRoleDao : IUserRoleDao
    {
        public void AddRoleForUser(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoleForUser(int userId, int roleId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAllRolesByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
