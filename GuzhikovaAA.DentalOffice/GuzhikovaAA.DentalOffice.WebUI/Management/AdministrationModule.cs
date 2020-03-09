using DentalOffice.BLL.Interfaces;
using DentalOffice.Common;
using DentalOffice.Entities;
using DentalOffice.WebUI.Log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;

namespace DentalOffice.WebUI.Management
{
    public class AdministrationModule
    {
        private IUsersLogic _userLogic = DependencyResolver.UsersLogic;
        private IRolesLogic _roleLogic = DependencyResolver.RolesLogic;

        private IPostsLogic _postLogic = DependencyResolver.PostsLogic;
        private IEmployeesLogic _employeesLogic = DependencyResolver.EmployeesLogic;
        private IPatientsLogic _patientsLogic = DependencyResolver.PatientsLogic;

        public IUsersLogic UserLogic => _userLogic;
        public IRolesLogic RoleLogic => _roleLogic;

        public List<User> GetUsers()
        {
            //try
            //{

            var users = _userLogic.GetAll().OrderBy(us => us.Login);
      
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return users.ToList();
        }

        public User GetUserById(int id)
        {
            //try
            //{
            User user = _userLogic.GetById(id);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return user;
        }
        public bool TryAuthenticateUser(HttpRequestBase request, out string errorMessage)
        {
            errorMessage = "";
            bool isAuthenticated = false;
            string login = request["login"];
            string password = request["password"];

            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                if (_userLogic.isPairLoginPassword(login, password))
                {
                    FormsAuthentication.SetAuthCookie(login, createPersistentCookie: true);
                    isAuthenticated = true;

                    Logger.Log.Info($"The user '{login}'  is successfully authenticated");

                }
                else
                {
                    errorMessage = "Неверная пара логин-пароль! Проверьте регистр и язык на клавиатуре и попробуйте войти снова.";
                    Logger.Log.Warn($"Authentication for user '{login}' rejected: invalid username/password pair");
                }
            }
            else
            {
                errorMessage = "К сожалению, не удалось получить данные логин/пароль. Обратитесь за помощью к администратору сайта.";
                Logger.Log.Error("Received data from Request about user login and password were null or empty");
            }

            return isAuthenticated;
        }

        public bool RegisterUser(HttpRequestBase request, out string message)
        {
            bool result = false;

            User user = GetOnlyUserInfoFromRequest(request);

            try
            {
               
              user =  GetRelatedUserInfoFromRequest(request, user)  ;
                _userLogic.Add(user);
                   
               // UpdateUser(user);

                
                result = true;
                //try
                //{

                FormsAuthentication.SetAuthCookie(user.Login, createPersistentCookie: true);
                message = "Поздравляем! Регистрация прошла успешно!";
            }
            catch (OperationCanceledException ex)
            {
                Logger.Log.Warn($"For user name '{user.Login}' occurred exception: {ex.Message}. {ex.StackTrace}");
                message = ("Регистрация отклонена, т.к. пользователь с таким именем уже существует. Пожалуйста, измените логин и повторите попытку.");
            }



            //}
            //catch
            //{
            // LOG --- MESSAGE
            //}
            return result;
        }

        public bool UpdateUser(User user)
        {
            bool result = false;
            try
            {
                _userLogic.Update(user);
                result = true;
            }
            catch (NullReferenceException ex)
            {
                StringBuilder mess = new StringBuilder($"Exception during the update user '{user.Login}', ID = {user.ID}:{Environment.NewLine}");
                mess.Append($"Message: {ex.Message}{Environment.NewLine}Stack Trace: {ex.StackTrace}");

                Exception innerEx = ex.InnerException;
                if (innerEx != null)
                {
                    mess.Append($"Inner exception: {innerEx.Message}{Environment.NewLine}Stack Trace: {innerEx.StackTrace}");
                }

                Logger.Log.Error(mess);
            }

            return result;
        }
        public List<Post> GetPosts()
        {
            return _postLogic.GetAll().ToList();
            //ДОПОЛНИТЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬ
        }

        public string GetUserPhoto(User user = null)
        {
            string src = (user != null && user.Photo != null)
                        ? $"data:image/png;base64,{Convert.ToBase64String(user.Photo)}"
                            : @"/Content/Images/user.png";

            return src;
        }


        public User GetEditedUserFromRequest(HttpRequestBase request)
        {
            Int32.TryParse(request["userId"], out int id);
            byte[] photo = GetAndResizeImageFromRequest();
            User user = null;

            if (id != 0)
            {
                user = GetUserById(id);

                user.Login = request["login"];

                if (!String.IsNullOrEmpty(request["password"]))
                {
                    user.Password = request["password"];
                }

                user.Email = request["email"];

                if (photo != null)
                {
                    user.Photo = photo;
                }
            }

            return user;

        }
        private User GetRelatedUserInfoFromRequest(HttpRequestBase request, User user)
        {
            Patient patient = null;
            Employee employee = null;

            bool isPatientExist = (request["patientExist"] == "exist");
            bool isEmployeeExist = (request["employeeExist"] == "exist");

            //if (!isPatientExist && !isEmployeeExist)
            //{
            //    return null;
            //}

            var patientRole = _roleLogic.GetByRoleName("Пациент");
            var employeeRole = _roleLogic.GetByRoleName("Сотрудник");
            user.Roles = new List<Role>();

            if (isPatientExist && isEmployeeExist)
            {
                patient = GetNewPatientFromRequest(request);
                employee = GetNewEmployeeFromRequest(request);

                employee.LastName = patient.LastName;
                employee.FirstName = patient.FirstName;
                employee.MiddleName = patient.MiddleName;

                user.PatientData = _patientsLogic.Add(patient);
                user.Roles.Add(patientRole);

                user.EmployeeData = _employeesLogic.Add(employee);
                user.Roles.Add(employeeRole);

            }
            else if (isPatientExist)
            {
                patient = GetNewPatientFromRequest(request);
                user.PatientData = _patientsLogic.Add(patient);
                user.Roles.Add(patientRole);
            }
            else if (isEmployeeExist)
            {
                employee = GetNewEmployeeFromRequest(request);
                user.EmployeeData = _employeesLogic.Add(employee);
                user.Roles.Add(employeeRole);
            }

            return user;
        }


        public List<Patient> GetPatients()
        {
           var patients =  _patientsLogic.GetAll().OrderBy(pat => pat.LastName);
            //ДОПОЛНИТЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬ

            return patients.ToList();
        }



        public List<Employee> GetEmployees()
        {
            var employees = _employeesLogic.GetAll().OrderBy(emp => emp.LastName);
            //ДОПОЛНИТЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬЬ

            return employees.ToList();
        }


        /// <summary>
        /// Gets user data from Request without related entities info
        /// </summary>
        /// <returns>Return object User</returns>
        private User GetOnlyUserInfoFromRequest(HttpRequestBase request)
        {
            User user = new User
            {
                Login = request["login"],
                Password = request["password"],
                Email = request["email"],
                RegistrationDate = DateTime.Now,
                Photo = GetAndResizeImageFromRequest()
            };

            return user;
        }

        private Employee GetNewEmployeeFromRequest(HttpRequestBase request)
        {
            DateTime.TryParse(request["dateOfBirth"], out DateTime dateOfBirth);
            DateTime.TryParse(request["dateOfEmployment"], out DateTime dateOfEmployment);
                 

            Employee employee = new Employee
            {
                LastName = request["empLastName"],
                FirstName = request["empFirstName"],
                MiddleName = request["empMiddleName"],
                DateOfBirth = dateOfBirth,
                DateOfEmployement = dateOfEmployment,
                Note = request["empNote"],
              //  Post = post
            };

            Int32.TryParse(request["post"], out int postID);

            if (postID != 0)
            {
                try
                {
                    employee.Post = _postLogic.GetById(postID);
                }
                catch
                {
                    ////////////////////////////////////////////////////
                    ////           LOG
                }
            }

            return employee;
        }

        private Patient GetNewPatientFromRequest(HttpRequestBase request)
        {
            Patient patient = new Patient
            {
                LastName = request["patientLastName"],
                FirstName = request["patientFirstName"],
                MiddleName = request["patientMiddleName"],
                Phone = request["patientPhone"]
            };
            return patient;
        }

        private byte[] GetAndResizeImageFromRequest(int width = 100, int height = 100)
        {
            byte[] imageBytes = null;
            WebImage image = WebImage.GetImageFromRequest();

            if (image != null)
            {
                image.Resize(width, height, false, true);

                imageBytes = image.GetBytes();
            }

            return imageBytes;
        }


    }

}