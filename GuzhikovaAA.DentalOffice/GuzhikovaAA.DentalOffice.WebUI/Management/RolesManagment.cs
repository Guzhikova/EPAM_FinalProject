using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DentalOffice.WebUI.Management
{
    public class RolesManagment
    {
        private IUsersLogic _userLogic = DependencyResolver.UsersLogic;
        private IRolesLogic _roleLogic = DependencyResolver.RolesLogic;


        public List<Role> GetRoles(out string message)
        {
            //try
            //{
            var roles = _roleLogic.GetAll().ToList();
            message = "";
            //}
            //catch (SQLEx)
            //{
            //   return new List<Role>(); или null??? В html - пока под null
            //}
            return roles;
        }
        public List<User> GetUsersForRole(int roleID, out string message)
        {
            //try
            //{
            var users = _userLogic.GetByRoleId(roleID).ToList();
            message = "";
            //}
            //catch (SQLEx)
            //{
            //   return new List<Role>(); или null??? В html - пока под null
            //}
            return users;
        }

    }
}