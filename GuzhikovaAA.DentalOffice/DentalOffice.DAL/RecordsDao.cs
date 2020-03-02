using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL
{
    public class RecordsDao : IRecordsDao
    {
        public Record Add(Record record)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
