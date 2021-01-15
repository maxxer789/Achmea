
using Achmea.Core.ContextModels;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IProject
    {
        public List<Project> GetProjectsFromUser(int userId);
        public Project AddNewProject(Project project, int[] MemberIDs);

        public IEnumerable<Project> GetProjects();

        public Project GetProject(int projectId);

        public List<SecurityRequirementProject> GetRequirementsForProject(int projectId);
        public List<Project> GetProjectsWithNeededActions(int userId);
        public List<ProjectMember> GetProjectMembers(int projectID);
        public Project GetReqProject(int reqID);
        public string GetSecReqProjName(int reqID);
    }
}
