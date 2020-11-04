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
        ProjectDAL projectDAL;

        readonly IProject _IUser;
        
        private IEnumerable<Project> Projects;
        private IEnumerable<SecurityRequirementProject> SecurityRequirementProjects;

        public ProjectLogic(IProject IUser)
        {
            projectDAL = new ProjectDAL();
            _IUser = IUser;

        }


        public Project MakeNewProject(Project projectModel)
        {
            try
            {
                return projectDAL.AddNewProject(projectModel);
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
            return projectDAL.GetEsaForProject(projectId);
        }

        public List<SecurityRequirementProject> GetRequirementsForProject(int projectId)
        {
            return projectDAL.GetRequirementsForProject(projectId);
        }

       // public Project GetProject(int projectId)
        //{
        // return Projects.FirstOrDefault(x => x.ProjectId == projectId);
        //}
    }
}
