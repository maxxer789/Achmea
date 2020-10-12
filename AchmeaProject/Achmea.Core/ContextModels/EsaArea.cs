using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class EsaArea
    {
        public EsaArea()
        {
            EsaAreaRequirement = new HashSet<EsaAreaRequirement>();
            EsaAspectArea = new HashSet<EsaAspectArea>();
        }

        public int AreaId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EsaAreaRequirement> EsaAreaRequirement { get; set; }
        public virtual ICollection<EsaAspectArea> EsaAspectArea { get; set; }
    }
}
