
using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
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

        public User GetUserByID(int id)
        {
            return _IUser.GetUserByID(id);
        }

        public int InsertUser(User user)
        {
            return _IUser.InsertUser(user);
        }

        public User Login(string Email)
        {
            return _IUser.GetUserByEmail(Email);
        }

        public void UpdateUser(User user)
        {
            _IUser.UpdateUser(user);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _IUser.GetAllUsers();
        }
    }
}
