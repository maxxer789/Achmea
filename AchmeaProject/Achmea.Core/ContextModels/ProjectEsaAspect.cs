using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class ProjectEsaAspect
    {
        public int ProjectEsaAspect1 { get; set; }
        public int ProjectId { get; set; }
        public int AspectId { get; set; }

        public virtual EsaAspect Aspect { get; set; }
        public virtual Project Project { get; set; }
    }
}
