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
    public class PagesLogic : IPagesLogic
    {
        private readonly IPagesDao _pagesDao;

        public PagesLogic(IPagesDao pagesDao)
        {
            _pagesDao = pagesDao;
        }

        public Page Add(Page page)
        {
            return _pagesDao.Add(page);
        }

        public void DeleteById(int id)
        {
            _pagesDao.DeleteById(id);
        }

        public IEnumerable<Page> GetAll()
        {
            return _pagesDao.GetAll();
        }

        public Page GetById(int id)
        {
            return _pagesDao.GetById(id);
        }

        public void Update(Page page)
        {
            _pagesDao.Update(page);
        }
    }
}
