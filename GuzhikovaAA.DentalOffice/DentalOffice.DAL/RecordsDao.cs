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
    public class RecordsDao : IRecordsDao
    {
        DBConnection _dbConnection = new DBConnection();
        public Record Add(Record record)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = record.Date },
                new SqlParameter() { ParameterName = "@patientID", SqlDbType = SqlDbType.Int, Value = record.Patient.ID },
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = record.Employee.ID },
                new SqlParameter() { ParameterName = "@comment", SqlDbType = SqlDbType.NVarChar, Value = record.Comment }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddRecord", parameters, idParameter);
            record.ID = (int)result;

            return record;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteRecordById", idParameter);
        }

        public IEnumerable<Record> GetAll()
        {
            return GetAllRecordsByParametrs("GetAllRecords");
        }

        public IEnumerable<Record> GetAllStartingFromDate(DateTime date)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = date }
            };

            return GetAllRecordsByParametrs("GetAllRecordsStartingFromDate", parameters);
        }

        public IEnumerable<Record> GetAllBetweenDates(DateTime date1, DateTime date2)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = date1 },
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = date2 }
            };

            return GetAllRecordsByParametrs("GetAllRecordsBetweenDates", parameters);
        }

        public IEnumerable<Record> GetAllOnDate(DateTime date)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = date }
            };

            return GetAllRecordsByParametrs("GetAllRecordsOnDate", parameters);
        }

        public Record GetById(int id)
        {
            Record record = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetRecordById";

                var idParameter = new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Value = id };
                command.Parameters.Add(idParameter);

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    record = new Record
                    {
                        ID = id,
                        Date = (reader["Date"] != DBNull.Value)
                            ? (DateTime)reader["Date"]
                            : default(DateTime),
                        Comment = reader["Comment"] as string
                    };

                    if (reader["PatientID"] != DBNull.Value)
                    {
                        record.Patient = new Patient
                        {
                            ID = (int)reader["PatientID"]
                        };
                    }

                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        record.Employee = new Employee
                        {
                            ID = (int)reader["EmployeeID"]
                        };
                    }
                }
            }
            return record;
        }

        public Record Update(Record record)
        {
            SqlParameter[] parameters =
             {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = record.ID},
                new SqlParameter() { ParameterName = "@date", SqlDbType = SqlDbType.DateTime2, Value = record.Date },
                new SqlParameter() { ParameterName = "@patientID", SqlDbType = SqlDbType.Int, Value = record.Patient.ID },
                new SqlParameter() { ParameterName = "@employeeID", SqlDbType = SqlDbType.Int, Value = record.Employee.ID },
                new SqlParameter() { ParameterName = "@comment", SqlDbType = SqlDbType.NVarChar, Value = record.Comment }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdateRecord", parameters);

            return record;
        }


        private List<Record> GetAllRecordsByParametrs(string storedProcedureName, SqlParameter[] parameters = null)
        {
            var records = new List<Record>();
            Record record = null;

            using (SqlConnection connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = storedProcedureName;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    record = new Record
                    {
                        ID = (int)reader["ID"],
                        Date = (reader["Date"] != DBNull.Value)
                            ? (DateTime)reader["Date"]
                            : default(DateTime),
                        Comment = reader["Comment"] as string
                    };

                    if (reader["PatientID"] != DBNull.Value)
                    {
                        record.Patient = new Patient
                        {
                            ID = (int)reader["PatientID"]
                        };
                    }

                    if (reader["EmployeeID"] != DBNull.Value)
                    {
                        record.Employee = new Employee
                        {
                            ID = (int)reader["EmployeeID"]
                        };
                    }

                    records.Add(record);
                }
            }
            return records;
        }
    }
}
