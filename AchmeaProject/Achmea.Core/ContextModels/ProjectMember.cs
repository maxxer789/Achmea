using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Achmea.Core.ContextModels
{
    public class ProjectMember
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User{get;set;}
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}

