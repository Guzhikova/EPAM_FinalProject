using DentalOffice.BLL.Interfaces;
using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL
{
    public class RolesLogic : IRolesLogic
    {
        private readonly IRolesDao _rolesDao;

        public RolesLogic(IRolesDao rolesDao)
        {
            _rolesDao = rolesDao;
        }

        public Role Add(Role role)
        {
            return _rolesDao.Add(role);
        }

        public void DeleteById(int id)
        {
            _rolesDao.DeleteById(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return _rolesDao.GetAll();
        }

        public Role GetById(int id)
        {
            return _rolesDao.GetById(id);
        }
        public Role GetByRoleName(string roleName)
        {
           
            return  _rolesDao.GetAll().FirstOrDefault
                (role => role.Title.ToLower() == roleName.ToLower());
        }
        public void Update(Role role)
        {
            _rolesDao.Update(role);
        }
    }
}
