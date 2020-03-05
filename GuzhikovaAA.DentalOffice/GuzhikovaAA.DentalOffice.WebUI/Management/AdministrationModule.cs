using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace DentalOffice.WebUI.Management
{
    public class AdministrationModule
    {
        private IUsersLogic _userLogic = DependencyResolver.UsersLogic;
        private IRolesLogic _roleLogic = DependencyResolver.RolesLogic;


        public string TryAuthenticateUser (HttpRequestBase request)
        {
            if (_userLogic.isPairLoginPassword(login, password))
            {
                FormsAuthentication.SetAuthCookie(login, createPersistentCookie: true);
            }
            return request["password"];
        }
    }
}