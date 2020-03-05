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
    public class PostsLogic : IPostsLogic
    {
        private readonly IPostsDao _postsDao;

        public PostsLogic(IPostsDao postsDao)
        {
            _postsDao = postsDao;
        }

        public Post Add(Post post)
        {
            return _postsDao.Add(post);
        }

        public void DeleteById(int id)
        {
            _postsDao.DeleteById(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postsDao.GetAll();
        }

        public Post GetById(int id)
        {
            return _postsDao.GetById(id);
        }

        public void Update(Post post)
        {
            _postsDao.Update(post);
        }
    }
}
