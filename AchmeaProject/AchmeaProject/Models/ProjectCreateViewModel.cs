using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ProjectCreateViewModel
    {
        public ProjectCreationDetailsViewModel Project { get; set; }
        public List<ESA_AspectViewModel> AspectAreas { get; set; }
        public List<BivViewModel> Bivs { get; set; }
    }
}
