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
    public class SpecialtiesDao : ISpecialtiesDao
    {
        DBConnection _dbConnection = new DBConnection();
        public Specialty Add(Specialty specialty)
        {
            SqlParameter[] parameters =
             {
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = specialty.Title },
                new SqlParameter() { ParameterName = "@category", SqlDbType = SqlDbType.NVarChar, Value = specialty.Category }
            };

            SqlParameter idParameter =
                new SqlParameter() { SqlDbType = SqlDbType.Int, ParameterName = "@id", Direction = ParameterDirection.Output };

            object result = _dbConnection.ExecuteStoredProcedure("dbo.AddSpecialty", parameters, idParameter);
            specialty.ID = (int)result;

            return specialty;
        }

        public void DeleteById(int id)
        {
            var idParameter = new SqlParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "@id",
                Value = id,
            };

            _dbConnection.ExecuteStoredProcedure("dbo.DeleteSpecialtyById", idParameter);
        }

        public IEnumerable<Specialty> GetAll()
        {
            throw new NotImplementedException();
        }

        public Specialty GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Specialty Update(Specialty specialty)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter() { ParameterName = "@id", SqlDbType = SqlDbType.Int, Value = specialty.ID},
                new SqlParameter() { ParameterName = "@title", SqlDbType = SqlDbType.NVarChar, Value = specialty.Title },
                new SqlParameter() { ParameterName = "@category", SqlDbType = SqlDbType.NVarChar, Value = specialty.Category }
            };

            _dbConnection.ExecuteStoredProcedure("dbo.UpdateSpecialty", parameters);

            return specialty;
        }
    }
}
