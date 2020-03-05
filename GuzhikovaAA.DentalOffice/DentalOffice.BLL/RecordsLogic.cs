using DentalOffice.BLL.Interfaces;
using DentalOffice.DAL.Interfaces;
using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL
{
    public class RecordsLogic : IRecordsLogic
    {
        private readonly IRecordsDao _recordsDao;

        public RecordsLogic(IRecordsDao recordsDao)
        {
            _recordsDao = recordsDao;
        }

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

        public IEnumerable<Record> GetAllBetweenDates(DateTime dateStart, DateTime dateEnd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAllOnDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAllStartingFromDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Record GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Record record)
        {
            throw new NotImplementedException();
        }
    }
}
