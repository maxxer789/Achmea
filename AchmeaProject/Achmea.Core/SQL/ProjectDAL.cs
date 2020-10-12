using Achmea.Core;
using Achmea.Core.Interface;
using Achmea.Core.Model;
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

    public class ProjectDAL : DbContext, IProject
    {
        List<ProjectModel> projectModels;
        ProjectModel projectModel;

        public ProjectDAL()
        {
            projectModels = new List<ProjectModel>();
            projectModel = new ProjectModel();
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

        public IEnumerable<Project> AddNewProject(ProjectModel projectModel)
        {

            //add
            Project project = new Project();
            project.Title = projectModel.GetTitle();
            project.UserId = projectModel.GetUser();
            project.CreationDate = projectModel.GetDate();
            project.Description = projectModel.GetDescription();
            project.Status = projectModel.GetStatus();

            Project.Add(project);
            SaveChanges();

            return Project.ToList();

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
