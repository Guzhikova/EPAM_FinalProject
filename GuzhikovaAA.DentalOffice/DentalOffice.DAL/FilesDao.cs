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
    public class FilesDao : IFilesDao
    {
        DBConnection _dbConnection = new DBConnection();
        public File Add(File file)
        {
            SqlParameter[] parameters =
              {
                new SqlParameter() { ParameterName = "@type", SqlDbType = SqlDbType.NVarChar, Value = file.Type },
                new SqlParameter() { ParameterName = "@name", SqlDbType = SqlDbType.NVarChar, Value = file.Name },
                new SqlParameter() { ParameterName = "@content", SqlDbType = SqlDbType.VarBinary, Value = file.Content }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddFile", parameters, idParameter);
            file.ID = (int)result;

            return file;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteFileById", idParameter);
        }

        public IEnumerable<File> GetAll()
        {
            var files = new List<File>();
            File file = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllFiles";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    file = new File
                    {
                        ID = (int)reader["ID"],
                        Type = reader["Type"] as string,
                        Name = reader["Name"] as string,
                        Content = reader["Content"] as byte[]
                    };
                    files.Add(file);
                }
            }
            return files;
        }

        public File GetById(int id)
        {
            File file = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetFileById";

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
                }
            }
            return file;
        }

        public File Update(File file)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = file.ID},
                new SqlParameter() { ParameterName = "@type", SqlDbType = SqlDbType.NVarChar, Value = file.Type },
                new SqlParameter() { ParameterName = "@name", SqlDbType = SqlDbType.NVarChar, Value = file.Name },
                new SqlParameter() { ParameterName = "@content", SqlDbType = SqlDbType.VarBinary, Value = file.Content }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdateFile", parameters);

            return file;
        }
    }
}
