using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Achmea.Core.SQL
{
    public class RequirementDAL : DatabaseHandler, IRequirement
    {
        public RequirementDAL()
        {

        }
        public List<RequirementModel> GetRequirements()
        {
            List<RequirementModel> requirements = new List<RequirementModel>();

            string query = "SELECT * FROM [Security_Requirement]";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            DataSet set = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(set);

            if (set != null)
            {
                int i = 0;
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    RequirementModel model = DatasetParser.DataSetToRequirement(set, i);
                    requirements.Add(model);
                    i++;
                }
            }
            con.Close();
            return requirements;
        }

        public List<RequirementProject> GetRequirementsForProject(int projectId)
        {
            List<RequirementProject> requirementProject = new List<RequirementProject>();

            string query = "SELECT * FROM [Security_Requirement-Project] WHERE ProjectID = @projectId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@projectId", projectId);
            con.Open();
            DataSet set = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(set);

            if (set != null)
            {
                int i = 0;
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    RequirementProject model = DatasetParser.DataSetToRequirementProject(set, i);
                    requirementProject.Add(model);
                    i++;
                }
            }
            con.Close();
            return requirementProject;
        }
    }
}
