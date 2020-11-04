﻿using Achmea.Core;
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
            project.Status = newProject.Status;

            Project.Add(project);
            SaveChanges();
            project.ProjectId = project.ProjectId;

            return project;

        }
       
        //public List<ProjectModel> GetProjects()
        //{
        //    string sql = "SELECT * FROM [Project]";

        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    con.Open();
        //    DataSet set = new DataSet();
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    adapter.Fill(set);

        //    List<ProjectModel> list = new List<ProjectModel>();
        //    if (set != null)
        //    {
        //        int i = 0;
        //        foreach (DataRow row in set.Tables[0].Rows)
        //        {
        //            ProjectModel model = DatasetParser.DataSetToProject(set, i);
        //            list.Add(model);
        //            i++;
        //        }
        //    }
        //    con.Close();
        //    return list;
        //}

        public IEnumerable<Project> GetProjects()
        {
            //Get
            return Project.ToList();
        }

        //public ProjectModel GetProject(int projectId)
        //{
        //    string sql = "SELECT * FROM [Project] WHERE ProjectID = @projectId";

        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    cmd.Parameters.AddWithValue("@projectId", projectId);
        //    con.Open();
        //    DataSet set = new DataSet();
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    adapter.Fill(set);

        //    ProjectModel project = new ProjectModel();
        //    if(set != null)
        //    {
        //        project = DatasetParser.DataSetToProject(set, 0);
        //    }
        //    return project;
        //}

        public Project GetProject(int projectId)
        {

            return Project.Where(project => project.ProjectId == projectId).SingleOrDefault();

        }

        public void AddNewProject(string title, int ID)
        {
            throw new NotImplementedException();
        }

        public List<EsaAspect> GetEsaForProject(int projectId)
        {
            List<EsaAspect> projectEsaAspects = new List<EsaAspect>();
            List<EsaAspect> esaAspects = new List<EsaAspect>(EsaAspect);

            foreach (ProjectEsaAspect projectEsa in ProjectEsaAspect)
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
            foreach (SecurityRequirementProject reqproject in SecurityRequirementProject)
            {
                if (reqproject.ProjectId == projectId)
                {
                    requirements.Add(reqproject);
                }
            }
            requirements = requirements.OrderBy(x => x.SecurityRequirementId).ToList();
            return requirements;
        }

        //Task<IEnumerable<ProjectModel>> Search(string SearchTerm)
        //{
        //    //IQueryable<ProjectModel> query = (IQueryable<ProjectModel>)GetProjects();

        //    //if (!string.IsNullOrEmpty(SearchTerm))
        //    //{
        //    //    query = query.Where(e => e.)
        //    //}
        //}

        //public List<ProjectModel> Search(string SearchTerm)
        //{
        //    List<ProjectModel> query = GetProjects();

        //    //if (!string.IsNullOrEmpty(SearchTerm))
        //    //{
        //    //    query = query.Where(e => e);
        //    //}
        //    return query;
        //}
    }
}
