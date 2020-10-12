using Achmea.Core.Interface;
using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Logic
{
    public class UserLogic
    {
        readonly IUser _IUser;

        public UserLogic(IUser IUser)
        {
            _IUser = IUser;
        }

        public void DeleteUser(int id)
        {
            _IUser.DeleteUser(id);
        }

        public UserModel GetUserByID(int id)
        {
            return _IUser.GetUserByID(id);
        }

        public int InsertUser(UserModel user)
        {
            return _IUser.InsertUser(user);
        }

        public UserModel Login(string Email)
        {
            return _IUser.Login(Email);
        }

        public void UpdateUser(UserModel user)
        {
            _IUser.UpdateUser(user);
        }
        public List<UserModel> GetAllUsers()
        {
            return _IUser.GetAllUsers();
        }
    }
}
