using System;
using System.Collections.Generic;

namespace AchmeaProject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int FileOfProofId { get; set; }
        public int RequirementId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public string Content { get; set; }
        public DateTime? PostDateTime { get; set; }

        public virtual FileOfProof FileOfProof { get; set; }
        public virtual Project Project { get; set; }
        public virtual SecurityRequirement Requirement { get; set; }
        public virtual User User { get; set; }
    }
}
