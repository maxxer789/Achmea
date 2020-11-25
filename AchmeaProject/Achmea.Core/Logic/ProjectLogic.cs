using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    //br
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

        public void UpdateProjectStatus(Project project)
        {
            _IProject.UpdateProjectStatus(project);
        }
    }
}
