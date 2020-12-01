using Achmea.Core.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchmeaProject.Models
{
    public partial class SecurityRequirementProject
    {
        public int SecurityRequirementProjectId { get; set; }
        public int ProjectId { get; set; }
        public int? FileOfProofId { get; set; }
        [ForeignKey("FileOfProofId")]
        public FileOfProof FileOfProof { get; set; }
        public int SecurityRequirementId { get; set; }
        public bool? Excluded { get; set; }
        public string Reason { get; set; }
        public _Status Status { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Project Project { get; set; }
        public virtual SecurityRequirement SecurityRequirement { get; set; }
    }
}
