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

        public void InitialRolesData(params string[] roleNames)
        {
            if (GetAll().Count() == 0)
            {
                for (int i = 0; i < roleNames.Length; i++)
                {
                    Add(new Role { ID = i, Title = roleNames[i] });
                }

            }
        }

        public Role Add(Role role)
        {
            if (GetByRoleName(role.Title) != null)
                throw new OperationCanceledException("Role with this title already exists! The role creation canceled.");

            return _rolesDao.Add(role);
        }

        public void DeleteById(int id)
        {
            _rolesDao.DeleteById(id);
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                return _rolesDao.GetAll();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public Role GetById(int id)
        {
            return _rolesDao.GetById(id);
        }
        public Role GetByRoleName(string roleName)
        {
            try
            {
                return _rolesDao.GetAll().FirstOrDefault
                                (role => role.Title.ToLower() == roleName.ToLower());
            }
            catch (NullReferenceException)
            {

                return null;
            }



        }
        public void Update(Role role)
        {
            _rolesDao.Update(role);
        }
    }
}
