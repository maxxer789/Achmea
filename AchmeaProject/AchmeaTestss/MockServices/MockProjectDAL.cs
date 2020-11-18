using Achmea.Core.Interface;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchmeaTestss.MockServices
{
    public class MockProjectDAL: IProject
    {
        private List<Project> Projects;

        public MockProjectDAL()
        {
            Projects
        }

        public Project AddNewProject(Project project, int[] MemberIDs)
        {
            return project;
        }

        public IEnumerable<Project> GetProjects()
        {
            List<Project> projects = new List<Project>();
            return projects;
        }

        public Project GetProject(int id)
        {
            Project project = new Project();
            return project;
        }

        public List<EsaAspect> GetEsaForProject(int id)
        {
            List<EsaAspect> aspectList = new List<EsaAspect>();
            return aspectList;
        }

        public List<SecurityRequirementProject> GetRequirementsForProject(int id)
        {
            List<SecurityRequirementProject> requirementList = new List<SecurityRequirementProject>();
            return requirementList;
        }
    }
}
