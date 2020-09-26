using DentalOffice.BLL;
using DentalOffice.BLL.Interfaces;
using DentalOffice.DAL;
using DentalOffice.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Common
{
    public class DependencyResolver
    {
        private static readonly IEmployeesDao _employeesDao;
        private static readonly IFilesDao _filesDao;
        private static readonly INewsDao _newsDao;
        private static readonly IPagesDao _pagesDao;
        private static readonly IPatientsDao _patientsDao;
        private static readonly IPostsDao _postsDao;
        private static readonly IRecordsDao _recordsDao;
        private static readonly IRolesDao _rolesDao;
        private static readonly ISpecialtiesDao _specialtiesDao;
        private static readonly IUsersDao _usersDao;

        private static readonly IEmployeesLogic _employeesLogic;
        private static readonly IFilesLogic _filesLogic;
        private static readonly INewsLogic _newsLogic;
        private static readonly IPagesLogic _pagesLogic;
        private static readonly IPatientsLogic _patientsLogic;
        private static readonly IPostsLogic _postsLogic;
        private static readonly IRecordsLogic _recordsLogic;
        private static readonly IRolesLogic _rolesLogic;
        private static readonly ISpecialtiesLogic _specialtiesLogic;
        private static readonly IUsersLogic _usersLogic;        

        static DependencyResolver()
        {
            _employeesDao = new EmployeesDao();
            _employeesLogic = new EmployeesLogic(_employeesDao);

            _filesDao = new FilesDao();
            _filesLogic = new FilesLogic(_filesDao);

            _newsDao = new NewsDao();
            _newsLogic = new NewsLogic(_newsDao);

            _pagesDao = new PagesDao();
            _pagesLogic = new PagesLogic(_pagesDao);

            _patientsDao = new PatientsDao();
            _patientsLogic = new PatientsLogic(_patientsDao);

            _postsDao = new PostsDao();
            _postsLogic = new PostsLogic(_postsDao);

            _recordsDao = new RecordsDao();
            _recordsLogic = new RecordsLogic(_recordsDao);

            _rolesDao = new RolesDao();
            _rolesLogic = new RolesLogic(_rolesDao);

            _specialtiesDao = new SpecialtiesDao();
            _specialtiesLogic = new SpecialtiesLogic(_specialtiesDao);

            _usersDao = new UsersDao();
            _usersLogic = new UsersLogic(_usersDao, _rolesDao);
        }

        public static IEmployeesDao EmployeesDao => _employeesDao;
        public static IFilesDao FilesDao => _filesDao;
        public static INewsDao NewsDao => _newsDao;
        public static IPagesDao PagesDao => _pagesDao;
        public static IPatientsDao PatientsDao => _patientsDao;
        public static IPostsDao PostsDao => _postsDao;
        public static IRecordsDao RecordsDao => _recordsDao;
        public static IRolesDao RolesDao => _rolesDao;
        public static ISpecialtiesDao SpecialtiesDao => _specialtiesDao;
        public static IUsersDao UsersDao => _usersDao;

        public static IEmployeesLogic EmployeesLogic => _employeesLogic;
        public static IFilesLogic FilesLogic => _filesLogic;
        public static INewsLogic NewsLogic => _newsLogic;
        public static IPagesLogic PagesLogic => _pagesLogic;
        public static IPatientsLogic PatientsLogic => _patientsLogic;
        public static IPostsLogic PostsLogic => _postsLogic;
        public static IRecordsLogic RecordsLogic => _recordsLogic;
        public static IRolesLogic RolesLogic => _rolesLogic;
        public static ISpecialtiesLogic SpecialtiesLogic => _specialtiesLogic;
        public static IUsersLogic UsersLogic => _usersLogic;


    }
}
