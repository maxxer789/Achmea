﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ProjectAddViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Members { get; set; }
    }
}
