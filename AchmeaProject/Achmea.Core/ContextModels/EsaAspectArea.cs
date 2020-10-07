using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class EsaAspectArea
    {
        public int EsaAspectAreaId { get; set; }
        public int EsaAspectId { get; set; }
        public int EsaAreaId { get; set; }

        public virtual EsaArea EsaArea { get; set; }
        public virtual EsaAspect EsaAspect { get; set; }
    }
}
