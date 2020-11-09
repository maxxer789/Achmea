using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Models
{
    public class ExcludeRequirementViewModel
    {
        public int RequirementId { get; set; }
        public int ProjectId { get; set; }
        public string Reason { get; set; }
    }
}
