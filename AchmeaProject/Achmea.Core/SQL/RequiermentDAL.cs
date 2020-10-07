using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Achmea.Core.SQL
{
    public class RequiermentDAL : BaseDAL, IRequirement
    {
        public RequiermentDAL(string Connectionstring) : base(Connectionstring)
        {

        }

        public List<RequirementModel> getRequiermentsFromAreas(List<AspectAreaModel> areas)
        {
            List<RequirementModel> requierments = new List<RequirementModel>();
            string sql = @"SELECT * FROM [Security_Requirement] AS SR WHERE SR.RequirementID IN
                            (SELECT RequirementID FROM[ESA-Aspect-Security_Requirement] WHERE AspectID IN
                                (SELECT ESA_AreaID FROM[ESA_Aspect-Area] AS EAA WHERE EAA.ESA_AspectID = @ID))";
            
            foreach (AspectAreaModel aspectArea in areas)
            {
                List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
                {
                    new KeyValuePair<object, object>("ID", aspectArea.AspectAreaId)
                };

                DataSet result = ExecuteSQL(sql, parameters);

                if (result != null)
                {
                    foreach(DataRow dr in result.Tables[0].Rows)
                    {
                        RequirementModel newRequierment = FillRequirment(dr);
                        if(requierments.Find(m => m.RequiermentID == newRequierment.RequiermentID) == null)
                        {
                            requierments.Add(newRequierment);
                        }
                    }
                }
            }

            return requierments;
        }

        private RequirementModel FillRequirment(DataRow dr)
        {
            return new RequirementModel(Convert.ToInt32(dr["RequirementID"]), dr["Name"].ToString(), dr["Description"].ToString(), dr["Details"].ToString(), dr["Family"].ToString(), dr["RequirementNumber"].ToString(), dr["MainGroup"].ToString(), 0);
        }
    }
}
