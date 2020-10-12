using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achmea.Core.Model
{
    public class RequirementProject
    {
        private int ProjectId { get; set; }
        private int RequirementId { get; set; }
        private bool Excluded { get; set; }
        private string Reason { get; set; }
        private string Status { get; set; }

        public RequirementProject(int projectId, int requirementId, bool excluded, string reason, string status)
        {
            ProjectId = projectId;
            RequirementId = requirementId;
            Excluded = excluded;
            Reason = reason;
            Status = status;
        }

        public int getReqId()
        {
            return RequirementId;
        }

        public string GetStatus()
        {
            return Status;
        }
    }
}
