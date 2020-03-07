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
    public class EmployeesDao : IEmployeesDao
    {
        private DBConnection _dbConnection = new DBConnection();
        private PostsDao _post = new PostsDao();
        private EmployeeFileDao _empFiles = new EmployeeFileDao();
        private EmployeeSpecialtyDao _empSpecialty = new EmployeeSpecialtyDao();


        public Employee Add(Employee employee)
        {
            employee = this.AddToSourceTable(employee);

            if (employee.Files != null)
            {
                foreach (var file in employee.Files)
                {
                    _empFiles.AddFileForEmployee(employee.ID, file.ID);
                }
            }

            if (employee.Specialties != null)
            {
                foreach (var specialty in employee.Specialties)
                {
                    _empSpecialty.AddSpecialtyForEmployee(employee.ID, specialty.ID);
                }
            }

            return employee;
        }        

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteEmployeeById", idParameter);
        }

        public IEnumerable<Employee> GetAll()
        {
            var employees = this.GetAllFromSourceTable();

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    employee.Post = _post.GetById(employee.Post.ID);
                    employee.Files = _empFiles.GetAllFilesByEmployeeId(employee.ID).ToList();
                    employee.Specialties = _empSpecialty.GetAllSpecialtiesByEmployeeId(employee.ID).ToList();
                }
            }
            return employees;
        }

        public Employee GetById(int id)
        {
            Employee employee = this.GetByIdFromSourceTable(id);

            if (employee != null)
            {
                employee.Post = _post.GetById(employee.Post.ID);

                employee.Files = _empFiles.GetAllFilesByEmployeeId(employee.ID).ToList();
                employee.Specialties = _empSpecialty.GetAllSpecialtiesByEmployeeId(employee.ID).ToList();
            }

            return employee; 

        }

        public void Update(Employee employee)
        {
            this.UpdateInSourceTable(employee);

            _empFiles.UpdateFilesForEmployee(employee);
            _empSpecialty.UpdateSpecialtiesForEmployee(employee);

        }



        private IEnumerable<Employee> GetAllFromSourceTable()
        {
            var employees = new List<Employee>();
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAllEmployees";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employee = new Employee
                    {
                        ID = (int)reader["ID"],
                        LastName = reader["LastName"] as string,
                        FirstName = reader["FirstName"] as string,
                        MiddleName = reader["MiddleName"] as string,
                        DateOfBirth = (reader["DateOfBirth"] != DBNull.Value)
                            ? (DateTime)reader["DateOfBirth"]
                            : default(DateTime),
                        DateOfEmployement = (reader["DateOfEmployment"] != DBNull.Value)
                            ? (DateTime)reader["DateOfEmployment"]
                            : default(DateTime),
                        Note = reader["Note"] as string
                    };

                    if (reader["PostID"] != DBNull.Value)
                    {
                        employee.Post = new Post
                        {
                            ID = (int)reader["PostID"]
                        };
                    }

                    employees.Add(employee);
                }
            }

            return employees;
        }        

        private Employee GetByIdFromSourceTable(int id)
        {
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetEmployeeById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    employee = new Employee
                    {
                        ID = id,
                        LastName = reader["LastName"] as string,
                        FirstName = reader["FirstName"] as string,
                        MiddleName = reader["MiddleName"] as string,
                        DateOfBirth = (reader["DateOfBirth"] != DBNull.Value)
                            ? (DateTime)reader["DateOfBirth"]
                            : default(DateTime),
                        DateOfEmployement = (reader["DateOfEmployment"] != DBNull.Value)
                            ? (DateTime)reader["DateOfEmployment"]
                            : default(DateTime),
                        Note = reader["Note"] as string
                    };

                    if (reader["PostID"] != DBNull.Value)
                    {
                        employee.Post = new Post
                        {
                            ID = (int)reader["PostID"]
                        };
                    }
                }
            }
            return employee;
        }

        private Employee AddToSourceTable(Employee employee)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = employee.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = employee.FirstName },

                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar,
                    Value = !String.IsNullOrEmpty(employee.MiddleName) ? (object) employee.MiddleName : DBNull.Value
                },

                new SqlParameter() { ParameterName = "@dateOfBirth", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfBirth },
                new SqlParameter() { ParameterName = "@dateOfEmployment", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfEmployement },
               
                new SqlParameter() { ParameterName = "@note", SqlDbType = SqlDbType.NVarChar, 
                    Value = !String.IsNullOrEmpty(employee.Note) ? (object) employee.Note : DBNull.Value },

                new SqlParameter() { ParameterName = "@postID", SqlDbType = SqlDbType.Int, 
                    Value = (employee.Post != null) ? (object) employee.Post.ID : DBNull.Value }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddEmployee", parameters, idParameter);
            employee.ID = (int)result;

            return employee;
        }

        private Employee UpdateInSourceTable(Employee employee)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = employee.ID},
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = employee.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = employee.FirstName },

                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar,
                    Value = !String.IsNullOrEmpty(employee.MiddleName) ? (object) employee.MiddleName : DBNull.Value },

                new SqlParameter() { ParameterName = "@dateOfBirth", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfBirth },
                new SqlParameter() { ParameterName = "@dateOfEmployment", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfEmployement },
               
                new SqlParameter() { ParameterName = "@note", SqlDbType = SqlDbType.NVarChar,
                    Value = !String.IsNullOrEmpty(employee.Note) ? (object) employee.Note : DBNull.Value },

                new SqlParameter() { ParameterName = "@postID", SqlDbType = SqlDbType.Int,
                    Value = (employee.Post != null) ? (object) employee.Post.ID : DBNull.Value }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdateEmployee", parameters);

            return employee;
        }

        
    }
}
