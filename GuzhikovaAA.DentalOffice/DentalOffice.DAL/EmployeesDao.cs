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
        DBConnection _dbConnection = new DBConnection();
        public Employee Add(Employee employee)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = employee.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = employee.FirstName },
                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar, Value = employee.MiddleName },
                new SqlParameter() { ParameterName = "@dateOfBirth", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfBirth },
                new SqlParameter() { ParameterName = "@dateOfEmployment", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfEmployement },
                new SqlParameter() { ParameterName = "@note", SqlDbType = SqlDbType.NVarChar, Value = employee.Note },
                new SqlParameter() { ParameterName = "@postID", SqlDbType = SqlDbType.Int, Value = employee.Post }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddEmployee", parameters, idParameter);
            employee.ID = (int)result;

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
            List<Employee> employees = new List<Employee>();
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

        public Employee GetById(int id)
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

        public Employee Update(Employee employee)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = employee.ID},
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = employee.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = employee.FirstName },
                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar, Value = employee.MiddleName },
                new SqlParameter() { ParameterName = "@dateOfBirth", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfBirth },
                new SqlParameter() { ParameterName = "@dateOfEmployment", SqlDbType = SqlDbType.DateTime2, Value = employee.DateOfEmployement },
                new SqlParameter() { ParameterName = "@note", SqlDbType = SqlDbType.NVarChar, Value = employee.Note },
                new SqlParameter() { ParameterName = "@postID", SqlDbType = SqlDbType.Int, Value = employee.Post }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdateEmployee", parameters);

            return employee;
        }
    }
}
