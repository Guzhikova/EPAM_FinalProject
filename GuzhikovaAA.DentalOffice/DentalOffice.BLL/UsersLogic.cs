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
        private readonly IUsersDao _usersDao;

        public UsersLogic(IUsersDao usersDao)
        {
            _usersDao = usersDao;
        }

        public User Add(User user)
        {
            if (GetByLogin(user.Login) != null)
                throw new OperationCanceledException("User with this login already exists! Operation to create user canceled.");

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
            return _usersDao.GetAll().FirstOrDefault
                (user => user.Login.ToLower() == login.ToLower());
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
    }
}
