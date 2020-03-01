using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Entities
{
    public class Page
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<File> Files { get; set; }
    }
}
