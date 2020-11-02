using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AchmeaProject.Models
{
    public class BIVRequirement
    {
        public int Id { get; set; }
        public int BivId { get; set; }
        [ForeignKey("BivId")]
        public Biv Biv { get; set; }
        public int RequirementId { get; set; }
        [ForeignKey("RequirementId")]
        public SecurityRequirement SecurityRequirement { get; set; }
    }
}
