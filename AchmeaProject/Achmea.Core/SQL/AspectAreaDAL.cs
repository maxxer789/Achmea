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
                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    int index = result.Tables[0].Rows.IndexOf(dr);
                    AspectAreaModel aspectarea = DatasetParser.DatasetToAspectArea(result, index);
                    aspects.Add(aspectarea);
                }
            }

            return aspects;
        }

        public AspectAreaModel GetAspectAreaById(int Id)
        {
            AspectAreaModel aspectarea = new AspectAreaModel();
            string sql = @"SELECT *
                              FROM[ESA_Aspect]
                              WHERE AspectID = @ID";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
                {
                    new KeyValuePair<object, object>("ID", Id)
                };

            DataSet result = ExecuteSQL(sql, parameters);


            AspectAreaModel aspects = new AspectAreaModel();

            if (result != null)
            {
                aspectarea = DatasetParser.DatasetToAspectArea(result, 0);
            }
            return aspectarea;
        }
    }
}
