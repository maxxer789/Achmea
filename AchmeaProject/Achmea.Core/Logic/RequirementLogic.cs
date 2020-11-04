using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Achmea.Core.Logic
{
    public enum Status
    {
        ToDo,
        Completed,
        Declined,
        Excluded
    }

    public class RequirementLogic
    {
        private IRequirement _IReq;
        public RequirementLogic(IRequirement IReq)
        {
            _IReq = IReq;
        }

        public List<SecurityRequirement> GetAllRequirements()
        {
            return _IReq.GetAllRequirements();
        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromAreas(List<EsaAspect> aspects)
        {
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            requirements = _IReq.GetRequiermentsFromAreas(aspects).ToList();
            return requirements;
        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications)
        {
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            requirements = _IReq.getRequiermentsFromBiv(classifications).ToList();
            return requirements;
        }
        public IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<EsaAspect> aspects, List<Biv> bivs, Project project)
        {
            List<SecurityRequirement> bivRequirements = getRequiermentsFromBiv(bivs).ToList();
            List<SecurityRequirement> aspectRequirements = getRequiermentsFromAreas(aspects).ToList();
            List<SecurityRequirement> allRequirements = new List<SecurityRequirement>();

            allRequirements = bivRequirements.Where(r => aspectRequirements.Any(r2 => r2.RequirementId == r.RequirementId)).ToList();

            return _IReq.SaveReqruirementsToProject(allRequirements, project).ToList();
        }
    }
}
