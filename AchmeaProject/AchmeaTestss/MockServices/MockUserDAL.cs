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

        public MockUserDAL()
        {
            Users = Populate();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public User GetUserByID(int id)
        {
            return Users.Where(user => user.UserId == id).FirstOrDefault();
        }

        public int InsertUser(User user)
        {
            Users.Add(user);
            return user.UserId;
        }

        public void DeleteUser(int id)
        {
            User user = Users.Where(u => u.UserId == id).SingleOrDefault();
            Users.Remove(user);
        }

        public void UpdateUser(User givenUser)
        {
            User userOld = Users.Where(user => user.UserId == givenUser.UserId).FirstOrDefault();
            userOld = givenUser;
        }

        public User GetUserByEmail(string email)
        {
            return Users.Where(user => user.Email == email).SingleOrDefault();
        }

        public List<User> Populate()
        {
            List<User> _Users = new List<User>();
            _Users.Add(new User()
            {
                UserId = 1,
                Firstname = "Testy",
                Lastname = "McTesterson",
                Email = "test@test.com",
                Password = "password",
                PhoneNumber = 0612345678,
                RoleId = "Developer"
            });
            _Users.Add(new User()
            {
                UserId = 2,
                Firstname = "Method",
                Lastname = "McMethodson",
                Email = "test@test.nl",
                Password = "password2",
                PhoneNumber = 0687654321,
                RoleId = "Security"
            });
            _Users.Add(new User()
            {
                UserId = 3,
                Firstname = "Public",
                Lastname = "McPublicson",
                Email = "test@test.de",
                Password = "password3",
                PhoneNumber = 0618273465,
                RoleId = "Admin"
            });
            return _Users;
        }
    }
}
