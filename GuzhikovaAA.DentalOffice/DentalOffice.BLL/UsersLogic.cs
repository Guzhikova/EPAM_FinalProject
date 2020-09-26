using DentalOffice.BLL.Interfaces;
using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private IUsersDao _usersDao;
        private IRolesLogic _rolesLogic;


        public UsersLogic(IUsersDao usersDao, IRolesDao rolesDao)
        {
            _usersDao = usersDao;
            _rolesLogic = new RolesLogic(rolesDao);
        }


        public User Add(User user)
        {
            try { 
            if (GetByLogin(user.Login) != null)
                throw new OperationCanceledException("User with this login already exists! Operation to create user canceled.");
            }
            catch (NullReferenceException)
            {

            }
            user.Password = ConvertToMD5(user.Password);
            return _usersDao.Add(user);
        }

        public void DeleteById(int id)
        {
            _usersDao.DeleteById(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _usersDao.GetAll();
        }

        public User GetById(int id)
        {
            return _usersDao.GetById(id);
        }

        public void Update(User user)
        {
            _usersDao.Update(user);
        }

        public User GetByLogin(string login)
        {
            try
            {
                return _usersDao.GetAll().FirstOrDefault
                                    (user => user.Login.ToLower() == login.ToLower());
            }
            catch (System.ArgumentNullException)
            {
                return null;
            }
                

        }

        public IEnumerable<User> GetAllByRoleId(int id)
        {
            return _usersDao.GetAllByRoleId(id);
        }

        public bool isPairLoginPassword(string login, string password)
        {
            string passwordMD5 = ConvertToMD5(password);

            var user = this.GetByLogin(login);

            return (user != null && user.Password == passwordMD5);
        }

        private string ConvertToMD5(string password)
        {
            var md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public void InitialAdmin(User admin, string roleName)
        {
            var users = GetAll();

            if (users == null || users.Count() == 0)
            {
                Role role = _rolesLogic.GetByRoleName(roleName);

                if (role != null)
                {
                    admin.Roles = new List<Role> { role };
                    Add(admin);
                }
                else
                {
                    throw new OperationCanceledException($"The operation canceled because role '{roleName}' does not exist.");
                }
            }

        }
    }
}
