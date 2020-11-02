using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AchmeaProject.Models
{
    public class ProjectBiv
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int BivId { get; set; }
        [ForeignKey("BivId")]
        public Biv Biv { get; set; }
    }
}
