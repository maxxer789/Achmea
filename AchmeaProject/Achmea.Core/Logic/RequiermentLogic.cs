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
    public class RequiermentLogic
    {
        private IRequirement _IReq;
        public RequiermentLogic(IRequirement IReq)
        {
            _IReq = IReq;
        }

        public List<SecurityRequirement> getRequiermentsFromAreas(List<EsaAspect> aspects)
        {
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            requirements = _IReq.GetRequiermentsFromAreas(aspects).ToList();
            return requirements;
        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications)
        {
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            return requirements;
        }
        public IEnumerable<SecurityRequirementProject> SaveReqruirementsToProject(List<SecurityRequirement> requirements, int projectId)
        {
            
            return _IReq.SaveReqruirementsToProject(requirements, projectId).ToList();
        }
    }
}
