using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using DentalOffice.WebUI.Log4net;
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

        public IRolesLogic RoleLogic => _roleLogic;


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

        public bool AddRole(HttpRequestBase request, out string message)
        {
            message = "";
            bool result = false;
            string title = request["title"];

            if (!String.IsNullOrEmpty(title))
            {
                try
                {
                    Role role = new Role { Title = title };
                    _roleLogic.Add(role);
                    result = true;
                }
                catch (OperationCanceledException ex)
                {
                    Logger.Log.Warn($"For creating role '{title}' occurred exception: {ex.Message}. {ex.StackTrace}");
                    message = ("Роль с таким именем уже существует! Пожалуйста, измените название.");
                }
            }
            return result;
        }

        public void DeleteRole(HttpRequestBase request)
        {
            Int32.TryParse(request["id"], out int id);
            if(id != 0)
            {
                _roleLogic.DeleteById(id);
            }
        }

        public Role GetRole(HttpRequestBase request)
        {
            Role role = null;

            Int32.TryParse(request["id"], out int id);
            if (id != 0)
            {
                role = _roleLogic.GetById(id);
            }

            return role;
        }


    }
}