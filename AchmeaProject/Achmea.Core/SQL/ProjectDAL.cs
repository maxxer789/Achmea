using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AchmeaProject.Database
{
    public class ProjectDAL : DatabaseHandler
    {
        public void AddNewProject(string title, int ID)
        {
            ID = 1;
            SqlCommand cmd = new SqlCommand(@"INSERT INTO[dbo].[Playlist] (Title, userID) values (@Title, @userID)", con);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@userID", ID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
