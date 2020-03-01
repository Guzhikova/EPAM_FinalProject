using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.DAL.Interfaces
{
    public interface IPostsDao
    {
        IEnumerable<Post> GetAll();

        Post GetById(int id);

        Post Add(Post post);

        Post Update(Post post);

        void DeleteById(int id);
    }
}
