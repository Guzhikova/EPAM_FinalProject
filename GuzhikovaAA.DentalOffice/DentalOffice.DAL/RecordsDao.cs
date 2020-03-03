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
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAllStartingFromDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAllBetweenDates(DateTime date1, DateTime date2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAllOnDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Record GetById(int id)
        {
            throw new NotImplementedException();
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
    }
}
