using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class EsaAspect
    {
        public EsaAspect()
        {
            EsaAspectArea = new HashSet<EsaAspectArea>();
            ProjectEsaAspect = new HashSet<ProjectEsaAspect>();
        }

        public int AspectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EsaAspectArea> EsaAspectArea { get; set; }
        public virtual ICollection<ProjectEsaAspect> ProjectEsaAspect { get; set; }
    }
}
