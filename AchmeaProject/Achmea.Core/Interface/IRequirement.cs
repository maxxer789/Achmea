using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
   public interface IRequirement
    {
        SecurityRequirement GetRequirementById(int Id);
        IEnumerable<SecurityRequirement> GetRequiermentsFromAreas(List<EsaAspect> aspects);
        IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications);
        IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, Project project);
    }
}
