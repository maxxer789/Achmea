using Achmea.Core.Interface;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchmeaTestss.MockServices
{
    class MockUserDAL : IUser
    {
        private List<User> Users;
        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public User GetUserByID(int id)
        {
            return Users.Where(user => user.UserId == id).FirstOrDefault();
        }

        public User InsertUser(User user)
        {
            Users.Add(user);
            return user;
        }

        public void DeleteUser(int id)
        {
            User user = Users.Where(u => u.UserId == id).SingleOrDefault();
            Users.Remove(user);
        }

        public void UpdateUser(User givenUser)
        {
            
        }

        public User GetUserByEmail(string email)
        {
            return Users.Where(user => user.Email == email).SingleOrDefault();
        }

        public List<User> GetMembersByProjectId(int projectId)
        {
            return Users;
        }
    }
}
