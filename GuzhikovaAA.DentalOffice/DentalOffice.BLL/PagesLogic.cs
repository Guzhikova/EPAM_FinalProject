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
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Page> GetAll()
        {
            throw new NotImplementedException();
        }

        public Page GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Page page)
        {
            throw new NotImplementedException();
        }
    }
}
