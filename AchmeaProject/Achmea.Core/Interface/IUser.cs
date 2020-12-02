    
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achmea.Core.Interface
{
    public interface IUser
    {
        User GetUserByID(int id);
        User InsertUser(User givenUser);
        void DeleteUser(int id);
        void UpdateUser(User givenUser);
        IEnumerable<User> GetAllUsers();
        User GetUserByEmail(string email);
        List<User> GetMembersByProjectId(int projectId);
    }
}
