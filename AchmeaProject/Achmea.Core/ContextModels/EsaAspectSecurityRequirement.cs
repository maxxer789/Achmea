using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class EsaAspectSecurityRequirement
    {
        public int EsaAspectSecurityRequirementId { get; set; }
        public int AspectId { get; set; }
        public int RequirementId { get; set; }
    }
}
