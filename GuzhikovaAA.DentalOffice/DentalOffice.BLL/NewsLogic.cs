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
    public class NewsLogic : INewsLogic
    {
        private readonly INewsDao _newsDao;

        public NewsLogic(INewsDao newsDao)
        {
            _newsDao = newsDao;
        }

        public News Add(News news)
        {
            return _newsDao.Add(news);
        }

        public void DeleteById(int id)
        {
            _newsDao.DeleteById(id);
        }

        public IEnumerable<News> GetAll()
        {
            return _newsDao.GetAll();
        }

        public News GetById(int id)
        {
            return _newsDao.GetById(id);
        }

        public void Update(News news)
        {
            _newsDao.Update(news);
        }
    }
}
