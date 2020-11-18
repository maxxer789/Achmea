using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AchmeaProject.Core
{
    public class DatabaseHandler
    {

        public SqlConnectionStringBuilder builder { get; private set; }
        public SqlDataReader dataReader { get; set; }
        public SqlConnection con { get; private set; }
        public DataTable table { get; private set; }

        public DatabaseHandler()
        {
            builder = new SqlConnectionStringBuilder();

            builder.DataSource = "mssql.fhict.local";
            builder.UserID = "dbi429901_achmea";
            builder.Password = "achmeagroep";
            builder.InitialCatalog = "dbi429901_achmea";

            con = new SqlConnection(builder.ConnectionString);
            table = new DataTable();
        }

    }
}
