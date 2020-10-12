using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Achmea.Core.SQL
{
    public class BivDAL : BaseDAL, IBiv
    {
        public BivDAL(string Connectionstring) : base(Connectionstring)
        {

        }

        public List<BivModel> GetBiv()
        {
            string sql = "SELECT * FROM [BIV]";

            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
            {

            };

            DataSet result = ExecuteSQL(sql, parameters);


            List<BivModel> bivs = new List<BivModel>();

            if (result != null)
            {
                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    int index = result.Tables[0].Rows.IndexOf(dr);
                    BivModel biv = DatasetParser.DatasetToBiv(result, index);
                    bivs.Add(biv);
                }
            }

            return bivs;
        }
    }
}
