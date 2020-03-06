using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    public class UsersDao : IUsersDao
    {
        private DBConnection _dbConnection = new DBConnection();
        private EmployeesDao _employees = new EmployeesDao();
        private PatientsDao _patients = new PatientsDao();
        private UserRoleDao _userRole = new UserRoleDao();

        public IEnumerable<User> GetAll()
        {
            var users = this.GetAllFromSourceTable();

            if (users != null)
            {
                foreach (var user in users)
                {
                    if (user.EmployeeData != null)
                    {
                        user.EmployeeData = _employees.GetById(user.EmployeeData.ID);
                    }

                    if (user.PatientData != null)
                    {
                        user.PatientData = _patients.GetById(user.PatientData.ID);
                    }

                    if (user.Roles != null)
                    {
                        user.Roles = _userRole.GetAllRolesByUserId(user.ID).ToList();
                    }
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            User user = this.GetByIdFromSourceTable(id);

            if (user != null)
            {
                user.EmployeeData = _employees.GetById(user.EmployeeData.ID);
                user.PatientData = _patients.GetById(user.PatientData.ID);
                user.Roles = _userRole.GetAllRolesByUserId(user.ID).ToList();
            }
            return user;
        }

        public User Add(User user)
        {
            user = AddToSourceTable(user);

            foreach (var role in user.Roles)
            {
                _userRole.AddRoleForUser(user.ID, role.ID);
            }

            return user;
        }       

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteUserById", idParameter);
        }

        public void Update(User user)
        {
            this.UpdateInSourceTable(user);
            _userRole.UpdateRolesForUser(user);
        }


        private User AddToSourceTable(User user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@login", SqlDbType = SqlDbType.NVarChar, Value = user.Login },
                new SqlParameter() { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = user.Password },
                new SqlParameter() { ParameterName = "@email", SqlDbType = SqlDbType.NVarChar, Value = user.Email },
                new SqlParameter() { ParameterName = "@registrationDate", SqlDbType = SqlDbType.DateTime2, Value = user.RegistrationDate },
                new SqlParameter() { ParameterName = "@photo", SqlDbType = SqlDbType.VarBinary, Value = user.Photo },
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = user.EmployeeData.ID },
                new SqlParameter() { ParameterName = "@patientID", SqlDbType = SqlDbType.Int, Value = user.PatientData.ID },
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddUser", parameters, idParameter);
            user.ID = (int)result;

            return user;
        }

        private IEnumerable<User> GetAllFromSourceTable()
        {
            var users = new List<User>();
            User user = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllUsers";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        ID = (int)reader["ID"],
                        Login = reader["Login"] as string,
                        Password = reader["Password"] as string,
                        Email = reader["Email"] as string,
                        RegistrationDate = (reader["RegistrationDate"] != DBNull.Value)
                            ? (DateTime)reader["RegistrationDate"]
                            : default(DateTime),
                        Photo = reader["Photo"] as byte[]
                    };

                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        user.EmployeeData = new Employee
                        {
                            ID = (int)reader["EmployeeID"]
                        };
                    }

                    if (reader["PatientID"] != DBNull.Value)
                    {
                        user.PatientData = new Patient
                        {
                            ID = (int)reader["PatientID"]
                        };
                    }
                    users.Add(user);
                }
            }
            return users;
        }

        private User GetByIdFromSourceTable(int id)
        {
            User user = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User
                    {
                        ID = id,
                        Login = reader["Login"] as string,
                        Password = reader["Password"] as string,
                        Email = reader["Email"] as string,
                        RegistrationDate = (reader["RegistrationDate"] != DBNull.Value)
                            ? (DateTime)reader["RegistrationDate"]
                            : default(DateTime),
                        Photo = reader["Photo"] as byte[]
                    };

                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        user.EmployeeData = new Employee
                        {
                            ID = (int)reader["EmployeeID"]
                        };
                    }

                    if (reader["PatientID"] != DBNull.Value)
                    {
                        user.PatientData = new Patient
                        {
                            ID = (int)reader["PatientID"]
                        };
                    }
                }
            }
            return user;
        }

        private void UpdateInSourceTable(User user)
        {
            SqlParameter[] parameters =
           {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = user.ID},
                new SqlParameter() { ParameterName = "@login", SqlDbType = SqlDbType.NVarChar, Value = user.Login },
                new SqlParameter() { ParameterName = "@password", SqlDbType = SqlDbType.NVarChar, Value = user.Password },
                new SqlParameter() { ParameterName = "@email", SqlDbType = SqlDbType.NVarChar, Value = user.Email },
                new SqlParameter() { ParameterName = "@registrationDate", SqlDbType = SqlDbType.DateTime2, Value = user.RegistrationDate },
                new SqlParameter() { ParameterName = "@photo", SqlDbType = SqlDbType.VarBinary, Value = user.Photo },
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = user.EmployeeData.ID },
                new SqlParameter() { ParameterName = "@patientID", SqlDbType = SqlDbType.Int, Value = user.PatientData.ID }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.AddUser", parameters);
        }

 
    }
}
