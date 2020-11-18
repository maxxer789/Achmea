
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IProject
    {
        public Project AddNewProject(Project project, int[] MemberIDs);

        public IEnumerable<Project> GetProjects();

        public Project GetProject(int projectId);

        public List<EsaAspect> GetEsaForProject(int projectId);

        public List<SecurityRequirementProject> GetRequirementsForProject(int projectId);

    }
}
