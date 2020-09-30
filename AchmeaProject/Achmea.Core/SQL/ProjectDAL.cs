using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Database
{

    public class ProjectDAL : DatabaseHandler, IProject
    {
        public void AddNewProject(ProjectModel projectModel)
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
    }
}
