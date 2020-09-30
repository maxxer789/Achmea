using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Achmea.Core.SQL
{
    public class UserDAL : BaseDAL, IUser
    {
        public UserDAL(string Connectionstring) : base(Connectionstring)
        {

        }
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public int InsertUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public UserModel Login(string Email)
        {
            string sql = "SELECT * FROM [User] WHERE Email = @Email";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
            {
                new KeyValuePair<object, object>("Email", Email)
            };
            DataSet result = ExecuteSQL(sql, parameters);
            UserModel user = null;
            if (result != null)
            {
                user = DatasetParser.DatasetToUser(result, 0);
            }
            return user;
        }

        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
