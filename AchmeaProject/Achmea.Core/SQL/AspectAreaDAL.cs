using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Achmea.Core.SQL
{
    public class AspectAreaDAL : AchmeaContext, IAspectArea
    {
        public AspectAreaDAL() : base()
        {

        }

        public List<EsaAspect> GetAspectAreas()
        {
            return EsaAspect.ToList();
            //string sql = "SELECT * FROM [ESA_Aspect]";

            //List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
            //{

            //};

            //DataSet result = ExecuteSQL(sql, parameters);


            //List<AspectAreaModel> aspects = new List<AspectAreaModel>();

            //if (result != null)
            //{
            //        foreach (DataRow dr in result.Tables[0].Rows)
            //        {
            //            int index = result.Tables[0].Rows.IndexOf(dr);
            //            AspectAreaModel aspectarea = DatasetParser.DatasetToAspectArea(result, index);
            //            aspects.Add(aspectarea);
            //        }
            //}

            //return aspects;
        }
    }
}
