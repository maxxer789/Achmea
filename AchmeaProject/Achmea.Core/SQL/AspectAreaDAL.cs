using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Achmea.Core.SQL
{
    public class AspectAreaDAL : BaseDAL, IAspectArea
    {
        public AspectAreaDAL(string Connectionstring) : base(Connectionstring)
        {

        }

        public List<AspectAreaModel> GetAspectAreas()
        {
            string sql = "SELECT * FROM [ESA_Aspect]";

            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
            {
                
            };

            DataSet result = ExecuteSQL(sql, parameters);


            List<AspectAreaModel> aspects = new List<AspectAreaModel>();

            if (result != null)
            {
                foreach (int dr in result.Tables[0].Rows)
                {
                    AspectAreaModel aspectarea = DatasetParser.DatasetToAspectArea(result, dr);
                    aspects.Add(aspectarea);
                }
            }

            return aspects;
        }
    }
}
