﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalOffice.Entities
{
    public class File
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
