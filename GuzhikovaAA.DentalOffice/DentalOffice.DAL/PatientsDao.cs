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
    public class PatientsDao : IPatientsDao
    {
        DBConnection _dbConnection = new DBConnection();
        public Patient Add(Patient patient)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = patient.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = patient.FirstName },
                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar, Value = patient.MiddleName },
                new SqlParameter() { ParameterName = "@phone", SqlDbType = SqlDbType.NVarChar, Value = patient.Phone }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddPatient", parameters, idParameter);
            patient.ID = (int)result;

            return patient;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeletePatientById", idParameter);
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Patient Update(Patient patient)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = patient.ID},
                new SqlParameter() { ParameterName = "@lastName", SqlDbType = SqlDbType.NVarChar, Value = patient.LastName },
                new SqlParameter() { ParameterName = "@firstName", SqlDbType = SqlDbType.NVarChar, Value = patient.FirstName },
                new SqlParameter() { ParameterName = "@middleName", SqlDbType = SqlDbType.NVarChar, Value = patient.MiddleName },
                new SqlParameter() { ParameterName = "@phone", SqlDbType = SqlDbType.NVarChar, Value = patient.Phone }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdatePatient", parameters);

            return patient;
        }
    }
}
