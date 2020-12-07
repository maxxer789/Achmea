using Achmea.Core.Logic;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
   public interface IRequirement
    {
        List<SecurityRequirement> GetAllRequirements();
        SecurityRequirement GetRequirementById(int Id);
        IEnumerable<SecurityRequirement> GetRequiermentsFromAreas(List<EsaAspect> aspects);
        IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications);
        IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, Project project);
        SecurityRequirement ExcludeRequirement(int requirementId, int projectId, string reason);
        SecurityRequirement CreateRequirement(SecurityRequirement req, List<int> bivIds, List<int> areaIds);
        public void UpdateRequirentStatus(SecurityRequirementProject givenRequirement, _Status newStatus);

    }
}
