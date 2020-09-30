using Achmea.Core;
using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Achmea.Core
{

    public class ProjectDAL : DatabaseHandler, IProject
    {
        public ProjectDAL(string ConnectionString)
        {

        }

        public void AddNewProject(string title, int ID)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO[dbo].[Project] (Title, userID, CreationDate, Description, Status) values (@Title, @userID, @Date, @Description, @Status)", con);
            cmd.Parameters.AddWithValue("@Title", projectModel.GetTitle());
            cmd.Parameters.AddWithValue("@userID", projectModel.GetUser());
            cmd.Parameters.AddWithValue("@Date", projectModel.GetDate());
            cmd.Parameters.AddWithValue("@Description", projectModel.GetDescription());
            cmd.Parameters.AddWithValue("@Status", projectModel.GetStatus());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<ProjectModel> GetProjects()
        {
            string sql = "SELECT * FROM [Project]";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            DataSet set = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(set);

            List<ProjectModel> list = new List<ProjectModel>();
            if (set != null)
            {
                int i = 0;
                foreach(DataRow row in set.Tables[0].Rows)
                {
                    ProjectModel model = DatasetParser.DataSetToProject(set, i);
                    list.Add(model);
                    i++;
                }
            }
            return list;
        }
    }
}
