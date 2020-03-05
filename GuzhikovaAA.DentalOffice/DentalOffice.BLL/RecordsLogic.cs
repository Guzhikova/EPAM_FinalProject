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
            return _recordsDao.Add(record);
        }

        public void DeleteById(int id)
        {
            _recordsDao.DeleteById(id);

        }

        public IEnumerable<Record> GetAll()
        {
            return _recordsDao.GetAll();
        }

        public IEnumerable<Record> GetAllBetweenDates(DateTime dateStart, DateTime dateEnd)
        {
            return _recordsDao.GetAllBetweenDates(dateStart, dateEnd);
        }

        public IEnumerable<Record> GetAllOnDate(DateTime date)
        {
            return _recordsDao.GetAllOnDate(date);
        }

        public IEnumerable<Record> GetAllStartingFromDate(DateTime date)
        {
            return _recordsDao.GetAllStartingFromDate(date);
        }

        public Record GetById(int id)
        {
            return _recordsDao.GetById(id);
        }

        public void Update(Record record)
        {
            _recordsDao.Update(record);
        }
    }
}
