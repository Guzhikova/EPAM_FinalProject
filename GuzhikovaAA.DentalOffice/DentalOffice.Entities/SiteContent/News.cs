using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Entities.Content
{
    public class News
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }

        public List<File> Files { get; set; }

    }
}
