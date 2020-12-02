using Achmea.Core;
using Achmea.Core.Interface;
using AchmeaProject.Core;
using AchmeaProject.Models;
using Dapper;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Achmea.Core.ContextModels;
using Microsoft.EntityFrameworkCore;

namespace Achmea.Core
{

    public class ProjectDAL : AchmeaContext, IProject
    {
        List<Project> projectModels;
        SecurityRequirementProject srpModel;
        Project newProject;

        public ProjectDAL()
        {
            projectModels = new List<Project>();
            newProject = new Project();
            srpModel = new SecurityRequirementProject();
        }
        
        public ProjectDAL(string ConnectionString)
        {

        }


        public Project AddNewProject(Project newProject, int[] MemberIds)
        {

            //add
            Project project = new Project();
            project.Title = newProject.Title;
            project.UserId = newProject.UserId;
            project.CreationDate = newProject.CreationDate;
            project.Description = newProject.Description;

            Project.Add(project);
            SaveChanges();

            foreach(int memberId in MemberIds)
            {
                ProjectMember projectMember = new ProjectMember();
                projectMember.UserId = memberId;
                projectMember.ProjectId = project.ProjectId;
                ProjectMembers.Add(projectMember);
            }
            SaveChanges();

            return project;

        }
       
        public IEnumerable<Project> GetProjects()
        {
            //Get
            return Project.ToList();
        }

        public Project GetProject(int projectId)
        {

            return Project.Where(project => project.ProjectId == projectId).SingleOrDefault();

        }

        public void AddNewProject(string title, int ID)
        {
            throw new NotImplementedException();
        }

        public List<SecurityRequirementProject> GetRequirementsForProject(int projectId)
        {
            List<SecurityRequirementProject> requirements = new List<SecurityRequirementProject>();
            foreach (SecurityRequirementProject reqproject in SecurityRequirementProject.Include(p => p.FileOfProof))
            {
                if (reqproject.ProjectId == projectId)
                {
                    requirements.Add(reqproject);
                }
            }
            requirements = requirements.OrderBy(x => x.SecurityRequirementId).ToList();
            return requirements;
        }

    }
}
