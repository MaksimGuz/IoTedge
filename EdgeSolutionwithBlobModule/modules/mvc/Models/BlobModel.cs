﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class BlobModel
    {
        public int Total { get; set; }
        public IList<KeyValuePair<string, string>> BlobItems { get; set; }
    }
}
