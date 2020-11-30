using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class SecurityRequirement
    {
        public SecurityRequirement()
        {
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

        public virtual ICollection<EsaAreaRequirement> EsaAreaRequirement { get; set; }
        public virtual ICollection<SecurityRequirementProject> SecurityRequirementProject { get; set; }

        public SecurityRequirement(int requirementId, string name, string description, string details, string family, string requirementNumber, string mainGroup)
        {
            RequirementId = requirementId;
            Name = name;
            Description = description;
            Details = details;
            Family = family;
            RequirementNumber = requirementNumber;
            MainGroup = mainGroup;
        }
        public SecurityRequirement(string name, string description, string details, string family, string requirementNumber, string mainGroup)
        {
            Name = name;
            Description = description;
            Details = details;
            Family = family;
            RequirementNumber = requirementNumber;
            MainGroup = mainGroup;
        }
    }
}
