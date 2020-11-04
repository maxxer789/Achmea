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

        //public void AddNewProject(ProjectModel projectModel)
        //{
        //    SqlCommand cmd = new SqlCommand(@"INSERT INTO[dbo].[Project] (Title, userID, CreationDate, Description, Status) values (@Title, @userID, @Date, @Description, @Status)", con);
        //    cmd.Parameters.AddWithValue("@Title", projectModel.GetTitle());
        //    cmd.Parameters.AddWithValue("@userID", projectModel.GetUser());
        //    cmd.Parameters.AddWithValue("@Date", projectModel.GetDate());
        //    cmd.Parameters.AddWithValue("@Description", projectModel.GetDescription());
        //    cmd.Parameters.AddWithValue("@Status", projectModel.GetStatus());
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}

        public Project AddNewProject(Project newProject)
        {

            //add
            Project project = new Project();
            project.Title = newProject.Title;
            project.UserId = newProject.UserId;
            project.CreationDate = newProject.CreationDate;
            project.Description = newProject.Description;
            project.Status = ProjectStatus.InProgress.ToString();

            Project.Add(project);
            SaveChanges();

            project.ProjectId = project.ProjectId;

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
