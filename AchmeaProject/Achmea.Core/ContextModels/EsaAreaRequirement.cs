using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class EsaAreaRequirement
    {
        public int EsaAreaRequirementId { get; set; }
        public int EsaAreaId { get; set; }
        public int RequirementId { get; set; }

        public virtual EsaArea EsaArea { get; set; }
        public virtual SecurityRequirement Requirement { get; set; }
    }
}
