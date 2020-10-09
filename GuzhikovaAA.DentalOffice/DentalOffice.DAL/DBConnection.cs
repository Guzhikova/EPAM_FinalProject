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
    internal class DBConnection
    {
        public string ConnectionString =>
           @"Data Source=(local)\SQLEXPRESS;Initial Catalog=DentalOffice_VS;Integrated Security=True";

        /// <summary>
        /// Executes stored procedure with input parameters.
        /// </summary>
        /// <param name="name">Name of stored procedure </param>
        /// <param name="parameters">Transmitted input SQL-parameters</param>
        /// <returns>Number of processed rows</returns>
        public int ExecuteStoredProcedure(string name, SqlParameter[] parameters)
        {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = name;

                    command.Parameters.AddRange(parameters);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
        }

        /// <summary>
        /// Executes stored procedure with one input parameter.
        /// </summary>
        /// <param name="name">Name of stored procedure </param>
        /// <param name="parameters">Transmitted input SQL-parameter (usually ID)</param>
        /// <returns>Number of processed rows</returns>
        public int ExecuteStoredProcedure(string name, SqlParameter parameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = name;

                command.Parameters.Add(parameter);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executes stored procedure with input parameters and one output parameter.
        /// </summary>
        /// <param name="name">Name of stored procedure </param>
        /// <param name="output">Output SQL-parameter name</param>
        /// <param name="parameters">Transmitted input SQL-parameters</param>
        /// <returns>Return value of output SQL-parameter. </returns>
        public object ExecuteStoredProcedure(string name, SqlParameter[] inputParameters, SqlParameter outputParameter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = name;

                command.Parameters.AddRange(inputParameters);
                command.Parameters.Add(outputParameter);

                connection.Open();
                int result = command.ExecuteNonQuery();

                return  outputParameter.Value;
            }
        }

        /// <summary>
        /// Executes stored procedure that returns files for entity.
        /// </summary>
        /// <param name="procedureName">The stored procedure name</param>
        /// <param name="id">The entity ID</param>
        /// <returns>Returns files for entity</returns>
        public IEnumerable<File> GetAllFilesByEntityId(string procedureName, int id)
        {
            var files = new List<File>();
            File file = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    file = new File
                    {
                        ID = id,
                        Type = reader["Type"] as string,
                        Name = reader["Name"] as string,
                        Content = reader["Content"] as byte[]
                    };
                    files.Add(file);
                }
            }
            return files;
        }

    }
}
