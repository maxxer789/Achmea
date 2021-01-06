using Achmea.Core.ContextModels;
using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    public enum ProjectStatus
    {
        InProgress,
        Completed
    }
    public class ProjectLogic
    {
        readonly IProject _IProject;

        public ProjectLogic(IProject iProject)
        {
            _IProject = iProject;

        }

        public List<Project> GetProjectsFromUser(int userId)
        {
            return _IProject.GetProjectsFromUser(userId);
        }

        public Project MakeNewProject(Project projectModel, int[] members)
        {
            try
            {
                return _IProject.AddNewProject(projectModel, members);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<Project> GetProjects()
        {
            return new List<Project>(_IProject.GetProjects());
        }

        public List<SecurityRequirementProject> GetRequirementsForProject(int projectId)
        {
            return _IProject.GetRequirementsForProject(projectId);
        }

        public Project GetProject(int projectId)
        {
            return _IProject.GetProject(projectId);
        }

        public List<Project> GetProjectsWithNeededActions(int userId)
        {
            return _IProject.GetProjectsWithNeededActions(userId);
        }

        public List<ProjectMember> GetProjectMembers(int projectID)
        {
            return _IProject.GetProjectMembers(projectID);
        }

        public Project GetReqProject(int reqID)
        {
            return _IProject.GetReqProject(reqID);
        }

        public string GetSecReqProjName(int reqID)
        {
            return _IProject.GetSecReqProjName(reqID);
        }
    }
}
