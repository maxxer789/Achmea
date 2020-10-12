﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class AspectSelectViewModel
    {
        public ProjectViewModel Project { get; set; }
        public List<ESA_AspectViewModel> AspectAreas { get; set; }

    }
}
