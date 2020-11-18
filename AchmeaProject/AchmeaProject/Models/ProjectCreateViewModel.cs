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
        public int[] Members { get; set; }

        public ProjectCreateViewModel()
        {
            AspectAreas = new List<ESA_AspectViewModel>();
            Bivs = new List<BivViewModel>();
            Members = new List<int>().ToArray();
        }
    }
}
