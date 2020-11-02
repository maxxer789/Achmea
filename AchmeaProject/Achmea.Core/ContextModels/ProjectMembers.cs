using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Achmea.Core.ContextModels
{
    public class ProjectMembers
    {
        public int Id { get; set; }
        public string User { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}

