using DentalOffice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.BLL.Interfaces
{
    public interface IPostsLogic
    {
        IEnumerable<Post> GetAll();

        Post GetById(int id);

        Post Add(Post post);

        void Update(Post post);

        void DeleteById(int id);
    }
}
