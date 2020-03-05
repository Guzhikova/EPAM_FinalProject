using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface INewsDao
    {
        IEnumerable<News> GetAll();

        News GetById(int id);

        News Add(News news);

        void DeleteById(int id);

        void Update(News news);
    }
}
