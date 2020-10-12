using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class Project
    {
        public Project()
        {
            Comment = new HashSet<Comment>();
            ProjectEsaAspect = new HashSet<ProjectEsaAspect>();
            SecurityRequirementProject = new HashSet<SecurityRequirementProject>();
        }

        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<ProjectEsaAspect> ProjectEsaAspect { get; set; }
        public virtual ICollection<SecurityRequirementProject> SecurityRequirementProject { get; set; }
    }
}
