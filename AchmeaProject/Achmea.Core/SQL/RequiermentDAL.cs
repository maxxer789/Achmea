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

        public List<RequirementModel> getRequiermentsFromAreas(List<string> areaNames, List<int> areaIDs)
        {
            List<RequirementModel> requierments = new List<RequirementModel>();
            string sql = "SELECT RequirementID FROM [ESA-Aspect-Security_Requirement] WHERE AspectID = @ID";

            //Als er van area een apparte class wordt gemaakt, wordt dit kijken naar elke area en daarvan het id halen.
            foreach (int id in areaIDs)
            {
                List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
                {
                    new KeyValuePair<object, object>("ID", id)
                };

                DataSet result = ExecuteSQL(sql, parameters);

                if (result != null)
                {
                    foreach(DataRow dr in result.Tables[0].Rows)
                    {
                        RequirementModel newRequierment = new RequirementModel(Convert.ToInt32(dr["RequirementID"]));
                        requierments.Add(newRequierment);
                    }
                }
            }

            return requierments;
        }
    }
}
