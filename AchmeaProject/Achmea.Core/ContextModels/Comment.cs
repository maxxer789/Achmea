using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AchmeaProject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int SecurityRequirementProjectId { get; set; }
        [ForeignKey("SecurityRequirementProjectId")]
        public SecurityRequirementProject SecurityRequirementProject { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Content { get; set; }
        public DateTime? PostDateTime { get; set; }

        public virtual User User { get; set; }
    }
}
