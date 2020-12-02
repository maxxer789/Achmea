
using Achmea.Core.Interface;
using Achmea.Core.Model;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Achmea.Core.SQL
{
    public class UserDAL : AchmeaContext, IUser
    {
        public UserDAL()
        {

        }


        public void DeleteUser(int id)
        {
            User user = new User() { UserId = id };
            User.Attach(user);
            User.Remove(user);
            SaveChanges();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return User.ToList();
        }

        public User GetUserByID(int id)
        {
            return User.Where(user => user.UserId == id).SingleOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return User.Where(user => user.Email == email).SingleOrDefault();
        }


        public User InsertUser(User givenUser)
        {
            User user = new User();
            user.Email = givenUser.Email;
            user.UserId = givenUser.UserId;
            user.Firstname = givenUser.Firstname;
            user.Lastname = givenUser.Lastname;
            user.Password = givenUser.Password;
            user.PhoneNumber = givenUser.PhoneNumber;
            user.RoleId = givenUser.RoleId;

            User.Add(user);
            SaveChanges();

            return user;
        }


        public void UpdateUser(User givenUser)
        {
            User user = new User() { UserId = givenUser.UserId };

            user.Email = givenUser.Email;
            user.Firstname = givenUser.Firstname;
            user.Lastname = givenUser.Lastname;
            user.Password = givenUser.Password;
            user.PhoneNumber = givenUser.PhoneNumber;
            user.RoleId = givenUser.RoleId;

            User.Attach(user);
            User.Update(user);
            SaveChanges();
        }
    }
}
