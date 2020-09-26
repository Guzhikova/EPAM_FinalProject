using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using DentalOffice.WebUI.Log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuzhikovaAA.DentalOffice.WebUI.Management
{
    public class InitialData
    {

        private readonly static IRolesLogic _roleLogic = DependencyResolver.RolesLogic;
        private readonly static IUsersLogic _userLogic = DependencyResolver.UsersLogic;

        public static void InitRoles()
        {
            _roleLogic.InitialRolesData("Админ", "Сотрудник", "Пациент");
        }

        public static void InitAdmin()
        {
            string role = "Админ";

            User admin = new User
            {
                ID = 1,
                Login = "Admin",
                Password = "123456",
                Email = "admin@mystom.ru",
                RegistrationDate = DateTime.Now
            };

            try
            {
                _userLogic.InitialAdmin(admin, role);
            }
            catch (OperationCanceledException ex)
            {
                Logger.LogShortErrorInfo(ex);

                _roleLogic.Add(new Role { ID = 1, Title = role });
                _userLogic.InitialAdmin(admin, role);
            }
        }
    }
}