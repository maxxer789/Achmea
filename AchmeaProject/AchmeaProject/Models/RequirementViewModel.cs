﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class RequirementViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Family { get; set; }
        public string RequirementNumber { get; set; }
        public string MainGroup { get; set; }

        public RequirementViewModel()
        {

        }

    }
}
