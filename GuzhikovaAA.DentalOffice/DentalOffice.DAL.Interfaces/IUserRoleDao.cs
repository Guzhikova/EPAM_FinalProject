using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IUserRoleDao
    {
        //The interface for work with the relationship table 'user_role' consisting only user ID and role ID

        IEnumerable<Role> GetAllRolesByUserId(int id);

        void AddRoleForUser(int userId, int roleId);

        void DeleteRoleForUser(int userId, int roleId);
    }
}
