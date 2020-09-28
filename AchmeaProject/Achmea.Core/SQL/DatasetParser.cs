using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Achmea.Core
{
    public class DatasetParser
    //Data uit Database wordt omgezet in een klasse.
    {
        public static UserModel DatasetToUser(DataSet D, int RowIndex)
        {
            return new UserModel()
            {
                UserID = Convert.ToInt32(D.Tables[0].Rows[RowIndex][0]),
                Email = D.Tables[0].Rows[RowIndex][1].ToString(),
                Password = D.Tables[0].Rows[RowIndex][2].ToString(),
                Firstname = D.Tables[0].Rows[RowIndex][3].ToString(),
                Lastname = D.Tables[0].Rows[RowIndex][4].ToString(),
                PhoneNumber = Convert.ToInt32(D.Tables[0].Rows[RowIndex][5]),
                RoleID = Convert.ToInt32(D.Tables[0].Rows[RowIndex][6]),
            };
        }
    }
}
