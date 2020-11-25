using Achmea.Core;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Core;
using AchmeaProject.Models;
using Achmea.Core.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Achmea.Core.ContextModels;

namespace Achmea.Core
{
    //brr
    public class ProjectDAL : AchmeaContext, IProject
    {
        List<Project> projectModels;
        Project newProject;

        public ProjectDAL()
        {
            projectModels = new List<Project>();
            newProject = new Project();
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
            project.Status = newProject.Status;

            Project.Add(project);
            SaveChanges();

            foreach(int memberId in MemberIds)
            {
                ProjectMember projectMember = new ProjectMember();
                projectMember.userId = memberId;
                projectMember.ProjectId = project.ProjectId;
                ProjectMembers.Add(projectMember);
            }
            SaveChanges();

            return project;

        }

        public void AddNewProject(string title, int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjects()
        {
            return Project.ToList();
        }

        public Project GetProject(int projectId)
        {
            return Project.Where(project => project.ProjectId == projectId).SingleOrDefault();
        }

        public List<EsaAspect> GetEsaForProject(int projectId)
        {
            List<EsaAspect> projectEsaAspects = new List<EsaAspect>();
            List<EsaAspect> esaAspects = new List<EsaAspect>(EsaAspect);

            foreach(ProjectEsaAspect projectEsa in ProjectEsaAspect)
            {
                if (projectEsa.ProjectId == projectId)
                {
                    projectEsaAspects.Add(esaAspects.Where(aspect => aspect.AspectId == projectEsa.AspectId).SingleOrDefault());
                }
            }
            projectEsaAspects = projectEsaAspects.OrderBy(esa => esa.AspectId).ToList();
            return projectEsaAspects;
        }

        public List<SecurityRequirementProject> GetRequirementsForProject(int projectId)
        {
            List<SecurityRequirementProject> requirements = new List<SecurityRequirementProject>();
            foreach(SecurityRequirementProject reqproject in SecurityRequirementProject)
            {
                if(reqproject.ProjectId == projectId)
                {
                    requirements.Add(reqproject);
                }
            }
            requirements = requirements.OrderBy(x => x.SecurityRequirementId).ToList();
            return requirements;
        }
    }
}
