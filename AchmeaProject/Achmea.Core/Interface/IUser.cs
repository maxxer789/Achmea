using Achmea.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IUser
    {
        UserModel GetUserByID(int id);
        UserModel Login(string Email);
        int InsertUser(UserModel user);
        void DeleteUser(int id);
        void UpdateUser(UserModel user);
    }
}
