using DentalOffice.BLL;
using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using DentalOffice.WebUI.Log4net;
using System.Configuration.Provider;

namespace DentalOffice.WebUI.Management
{
    public class DentalOfficeRoleProvider : RoleProvider
    {
        private IUsersLogic _userLogic = DependencyResolver.UsersLogic;
        private IRolesLogic _roleLogic = DependencyResolver.RolesLogic;

        public IRolesLogic RoleLogic => _roleLogic;
        public IUsersLogic UserLogic => _userLogic;

        public override bool IsUserInRole(string userName, string roleName)
        {
            if (roleName == null || roleName == "")
                throw new ProviderException("Role name cannot be empty or null.");

            if (userName == null || userName == "")
                throw new ProviderException("User name cannot be empty or null.");

            if (!RoleExists(roleName))
                throw new ProviderException("Role does not exist.");

            var user = new User();
            user = _userLogic.GetByLogin(userName);

            if (user != null)
            {
                var userRole = user.Roles.FirstOrDefault(role => role.Title == roleName);
                return (userRole != null);
            }
            else
            {
                return false;
            }
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            if (!String.IsNullOrEmpty(roleName))
            {
                Role role = new Role { Title = roleName };
                _roleLogic.Add(role);
            }
        }

        public bool CreateRole(string roleName, out string message)
        {
            message = "";
            bool result = false;

            if (!String.IsNullOrEmpty(roleName))
            {
                try
                {
                    Role role = new Role { Title = roleName };
                    _roleLogic.Add(role);
                    result = true;
                }
                catch (OperationCanceledException ex)
                {
                    Logger.Log.Warn($"For creating role '{roleName}' occurred exception: {ex.Message}. {ex.StackTrace}");
                    message = ("Роль с таким именем уже существует! Пожалуйста, измените название.");
                }
            }
            return result;
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {

            if (!RoleExists(roleName))
            {
                throw new ProviderException("Role does not exist.");
            }

            if (throwOnPopulatedRole && GetUsersInRole(roleName).Length > 0)
            {
                throw new ProviderException("Cannot delete a populated role.");
            }
            try
            {
                var role = _roleLogic.GetByRoleName(roleName);

                _roleLogic.DeleteById(role.ID);

            }
            catch (SqlException ex)
            {
                Logger.LogShortErrorInfo(ex);
                return false;
            }
            return true;

        }

        public Role GetRoleByID(int roleID)
        {
            if (!RoleExists(roleID))
            {
                throw new ProviderException("Role does not exist.");
            }

            Role role = new Role();

            role = _roleLogic.GetById(roleID);
            return role;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {

            var roles = GetRoles();

            var roleNames = new string[roles.Count()];

            if (roles.Count() > 0)
            {
                for (int i = 0; i < roles.Count(); i++)
                {
                    roleNames[i] = roles.ElementAt(i).Title;
                }
            }

            return roleNames;
        }

        public List<Role> GetRoles()
        {
            var roles = _roleLogic.GetAll().ToList();

            return roles;
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }



        public override string[] GetUsersInRole(string roleName)
        {

            if (roleName == null || roleName == "")
                throw new ProviderException("Role name cannot be empty or null.");
            if (!RoleExists(roleName))
                throw new ProviderException("Role does not exist.");

            var role = _roleLogic.GetByRoleName(roleName);

            var users = _userLogic.GetAllByRoleId(role.ID);

            var userNames = new string[users.Count()];

            if (users.Count() > 0)
            {
                for (int i = 0; i < users.Count(); i++)
                {
                    userNames[i] = users.ElementAt(i).Login;
                }
            }

            return userNames;
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            var role = _roleLogic.GetByRoleName(roleName);

            return (role != null);

        }

        public bool RoleExists(int roleID)
        {
            var role = _roleLogic.GetById(roleID);

            return (role != null);

        }

        public Role GetRoleFromRequest(HttpRequestBase request, string idParamName = "id")
        {
            Role role = new Role(); ;

            Int32.TryParse(request[idParamName], out int id);
            if (id != 0)
            {
                role = _roleLogic.GetById(id);
            }

            return role;
        }


        public List<User> GetUsersInRoleByRoleID(int roleID)
        {
            var users = new List<User>();
            users = _userLogic.GetAllByRoleId(roleID).ToList();
            return users;
        }
    }
}