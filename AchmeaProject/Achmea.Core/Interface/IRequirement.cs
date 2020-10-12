using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IRequirement
    {
        IEnumerable<SecurityRequirement> getRequiermentsFromAreas(List<EsaArea> areas);
        IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, int projectId);
    }
}
