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
            string Query = "DELETE FROM [User] WHERE UserID = @UserID";
            List<KeyValuePair<object, object>> Params = new List<KeyValuePair<object, object>>
            {
                new KeyValuePair<object, object>("UserID", id.ToString())
            };
            ExecuteSQL(Query, Params);
        }

        public List<UserModel> GetAllUsers()
        {
            string sql = "SELECT * FROM [User]";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>();
            DataSet results = ExecuteSQL(sql, parameters);

            List<UserModel> Users = new List<UserModel>();

            if (results != null)
            {
                for (int x = 0; x < results.Tables[0].Rows.Count; x++)
                {
                    UserModel U = DatasetParser.DatasetToUser(results, x);
                    Users.Add(U);
                }
            }
            return Users;
        }

        public UserModel GetUserByID(int id)
        {
            string sql = "SELECT * FROM [User] WHERE UserID = @UserID";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
            {
                new KeyValuePair<object, object>("UserID", id.ToString())
            };

            DataSet result = ExecuteSQL(sql, parameters);
            UserModel user = null;

            if (result != null)
            {
                user = DatasetParser.DatasetToUser(result, 0);
            }
            return user;
        }

        public int InsertUser(UserModel user)
        {
            string sql = "INSERT INTO [User](Email,Password,Firstname,Lastname,PhoneNumber,RoleID)" +
               "VALUES(@Email, @Password, @Firstname, @Lastname, @PhoneNumber, @RoleID) SELECT SCOPE_IDENTITY()";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
            {
                new KeyValuePair<object, object>("Email", user.Email),
                new KeyValuePair<object, object>("Password", user.Password),
                new KeyValuePair<object, object>("Firstname", user.Firstname),
                new KeyValuePair<object, object>("Lastname", user.Lastname),
                new KeyValuePair<object, object>("PhoneNumber", user.PhoneNumber),
                new KeyValuePair<object, object>("RoleID", user.RoleID.ToString())
            };
            DataSet result = ExecuteSQL(sql, parameters);
            user.UserID = (int)(decimal)result.Tables[0].Rows[0][0];
            return user.UserID;
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
            string sql = "UPDATE [User] SET Email=@Email, Password=@Password, Firstname=@Firstname, Lastname=@Lastname, PhoneNumber=@PhoneNumber, RoleID=@RoleID WHERE UserID=@UserID;";
            List<KeyValuePair<object, object>> parameters = new List<KeyValuePair<object, object>>
            {
                new KeyValuePair<object, object>("UserID", user.UserID.ToString()),
                new KeyValuePair<object, object>("Email", user.Email),
                new KeyValuePair<object, object>("Password", user.Password),
                new KeyValuePair<object, object>("Firstname", user.Firstname),
                new KeyValuePair<object, object>("Lastname", user.Lastname),
                new KeyValuePair<object, object>("PhoneNumber", user.PhoneNumber.ToString()),
                new KeyValuePair<object, object>("RoleID", user.RoleID)
            };
           DataSet result = ExecuteSQL(sql, parameters);
        }
    }
}
