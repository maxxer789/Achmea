using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IRequirement
    {
        IEnumerable<SecurityRequirement> GetRequiermentsFromAreas(List<EsaAspect> aspects);
        IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, int projectId);
    }
}
