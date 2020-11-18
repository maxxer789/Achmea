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
        
        private IEnumerable<Project> Projects;
        private IEnumerable<SecurityRequirementProject> SecurityRequirementProjects;

        public ProjectLogic(IProject IUser)
        {
            _IProject = IUser;

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
            return new List<Project>(Projects);
        }

        public List<EsaAspect> GetEsaForProject(int projectId)
        {
            return _IProject.GetEsaForProject(projectId);
        }

        public List<SecurityRequirementProject> GetRequirementsForProject(int projectId)
        {
            return _IProject.GetRequirementsForProject(projectId);
        }

       // public Project GetProject(int projectId)
        //{
        // return Projects.FirstOrDefault(x => x.ProjectId == projectId);
        //}
    }
}
