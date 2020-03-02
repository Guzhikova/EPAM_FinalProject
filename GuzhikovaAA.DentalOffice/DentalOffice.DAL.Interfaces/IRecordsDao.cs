using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IRecordsDao
    {
        IEnumerable<Record> GetAll();

        IEnumerable<Record> GetAllOnDate(DateTime date);

        IEnumerable<Record> GetAllStartingFromDate(DateTime date);

        IEnumerable<Record> GetAllBetweenDates(DateTime dateStart, DateTime dateEnd);

        Record GetById(int id);

        Record Add(Record record);

        Record Update(Record record);

        void DeleteById(int id);
    }
}
