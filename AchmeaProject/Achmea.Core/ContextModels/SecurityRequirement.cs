using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class SecurityRequirement
    {
        public SecurityRequirement()
        {
            Comment = new HashSet<Comment>();
            EsaAreaRequirement = new HashSet<EsaAreaRequirement>();
            SecurityRequirementProject = new HashSet<SecurityRequirementProject>();
        }

        public int RequirementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string Family { get; set; }
        public string RequirementNumber { get; set; }
        public string MainGroup { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<EsaAreaRequirement> EsaAreaRequirement { get; set; }
        public virtual ICollection<SecurityRequirementProject> SecurityRequirementProject { get; set; }
    }
}
