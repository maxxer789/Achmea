using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Achmea.Core
{
    public class BaseDAL
    {
        private static string source = "Server=mssql.fhict.local;Database=dbi429901_achmea;User Id=dbi429901_achmea;Password=achmeagroep";

        public BaseDAL(string ConnectionString)
        {
            source = ConnectionString;
        }
        public string ConnectionString
        {
            get
            {
                return source;
            }
        }

        public DataSet ExecuteSQL(string Query, List<KeyValuePair<object, object>> Params)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlConnection Conn = new SqlConnection(ConnectionString);
                SqlDataAdapter DA = new SqlDataAdapter();
                SqlCommand _cmd = Conn.CreateCommand();

                foreach (KeyValuePair<object, object> KVP in Params)
                {
                    SqlParameter Param = new SqlParameter
                    {
                        ParameterName = "@" + KVP.Key,
                        Value = KVP.Value
                    };
                    _cmd.Parameters.Add(Param);
                }
                _cmd.CommandText = Query;
                DA.SelectCommand = _cmd;

                Conn.Open();
                DA.Fill(DS);
                Conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return DS;
        }
    }
}
