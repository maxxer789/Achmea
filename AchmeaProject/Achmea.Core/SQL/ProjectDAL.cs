﻿using Achmea.Core;
using Achmea.Core.Interface;
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

    public class ProjectDAL : DbContext, IProject
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

        public IEnumerable<Project> AddNewProject(Project newProject)
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

            return Project.ToList();

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
    }
}
