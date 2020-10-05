using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class AspectSelectViewModel
    {
        public ProjectViewModel project { get; set; }
        public List<ESA_AspectViewModel> AspectAreas { get; set; }
    }
}
