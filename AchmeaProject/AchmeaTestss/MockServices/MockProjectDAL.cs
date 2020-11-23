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
            Projects.Add(new Project()
            {
                ProjectId = 1,
                UserId = 1,
                Title = "Test Project 1",
                Description = "This is the description for test project 1.",
                CreationDate = DateTime.Now
            });
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
