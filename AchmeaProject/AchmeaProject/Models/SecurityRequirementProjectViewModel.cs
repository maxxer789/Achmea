using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class SecurityRequirementProjectViewModel
    {
        public int SecurityRequirementProjectId { get; set; }
        public int ProjectId { get; set; }
        public int SecurityRequirementId { get; set; }
        public bool? Excluded { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        

        public virtual Project Project { get; set; }
        public virtual SecurityRequirement SecurityRequirement { get; set; }

        


    }
}
