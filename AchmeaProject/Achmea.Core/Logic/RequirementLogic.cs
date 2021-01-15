using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Achmea.Core.Logic
{
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

        public SecurityRequirement GetById(int Id)
        {
            return _IReq.GetRequirementById(Id);
        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromAreas(List<EsaAspect> aspects)
        {
            List<SecurityRequirement> requirements = _IReq.GetRequiermentsFromAreas(aspects).ToList();
            return requirements;
        }

        public IEnumerable<SecurityRequirement> getRequiermentsFromBiv(List<Biv> classifications)
        {
            List<SecurityRequirement> requirements =_IReq.getRequiermentsFromBiv(classifications).ToList();
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

        public SecurityRequirement ExcludeRequirement(int requirementId, int projectId, string reason)
        {
            return _IReq.ExcludeRequirement(requirementId, projectId, reason);
        }

        public SecurityRequirement CreateRequirement(SecurityRequirement req, List<int> bivIds, List<int> areaIds)
        {
            if (bivIds.Count <= 3 || areaIds.Count > 0)
            {
                return _IReq.CreateRequirement(req, bivIds, areaIds);
            }
            throw new ArgumentException();
        }

        public void UpdateRequirentStatus(SecurityRequirementProject requirement, _Status newStatus)
        {
            _IReq.UpdateRequirentStatus(requirement, newStatus);
        }
    }

    [Flags]
    public enum _Status
    {
        [Display(Name = "Bewijs toevoegen")]
        Submit_evidence,

        [Display(Name = "Onder inspectie")]
        Under_review,

        [Display(Name = "Geaccepteerd")]
        Approved,

        [Display(Name = "Geweigerd")]
        Declined,

        [Display(Name = "Uitgezonderd")]
        Excluded
    }
}
