using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Models;
using AchmeaTestss.MockServices;
using Google.Apis.Util;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AchmeaTestss.TestClasses
{
    [TestClass]
    public class UserTest
    {
        IUser Interface = new MockUserDAL();
        private readonly UserLogic _UserLogic;

        public UserTest()
        {
            _UserLogic = new UserLogic(Interface);
        }

        [TestMethod]
        public void CanCreateUser()
        {
            string firstName = "Joe";
            string lastName = "McJoeson";
            int userId = 4;
            string email = "joe@joe.nl";
            int phonenumber = 0681726345;
            string role = "Developer";

            User user = new User()
            {
                Firstname = firstName,
                Lastname = lastName,
                UserId = userId,
                Email = email,
                PhoneNumber = phonenumber,
                RoleId = role
            };

            Assert.IsNotNull(user);
            Assert.AreEqual(firstName, user.Firstname);
            Assert.AreEqual(lastName, user.Lastname);
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(phonenumber, user.PhoneNumber);
            Assert.AreEqual(role, user.RoleId);
        }

        [TestMethod]
        public void GetAllUsers()
        {
            List<User> users = _UserLogic.GetAllUsers().ToList();

            Assert.IsNotNull(users);
            Assert.AreEqual(3, users.Count);
        }

        [TestMethod]
        public void AddUser_Successful()
        {
            string firstName = "Joe";
            string lastName = "McJoeson";
            int userId = 4;
            string email = "joe@joe.nl";
            int phonenumber = 0681726345;
            string role = "Developer";

            User user = new User()
            {
                Firstname = firstName,
                Lastname = lastName,
                UserId = userId,
                Email = email,
                PhoneNumber = phonenumber,
                RoleId = role
            };

            List<User> usersOld = _UserLogic.GetAllUsers().ToList();
            _UserLogic.InsertUser(user);
            List<User> usersNew = _UserLogic.GetAllUsers().ToList();

            Assert.IsNotNull(usersNew);
            Assert.IsNotNull(usersOld);
            Assert.AreNotEqual(usersOld.Count, usersNew.Count);
        }

        [TestMethod]
        public void AddAndGetSingleUser()
        {
            string firstName = "Joe";
            string lastName = "McJoeson";
            int userId = 4;
            string email = "joe@joe.nl";
            int phonenumber = 0681726345;
            string role = "Developer";

            User user = new User()
            {
                Firstname = firstName,
                Lastname = lastName,
                UserId = userId,
                Email = email,
                PhoneNumber = phonenumber,
                RoleId = role
            };
            _UserLogic.InsertUser(user);

            User retrievedUser = _UserLogic.GetUserByID(userId);

            Assert.IsNotNull(retrievedUser);
            Assert.AreEqual(userId, retrievedUser.UserId);
            Assert.AreEqual(firstName, retrievedUser.Firstname);
            Assert.AreEqual(lastName, retrievedUser.Lastname);
            Assert.AreEqual(email, retrievedUser.Email);
            Assert.AreEqual(phonenumber, retrievedUser.PhoneNumber);
            Assert.AreEqual(role, retrievedUser.RoleId);
        }

        [TestMethod]
        public void DeleteUser()
        {
            int projectId = 1;
            List<User> usersOld = _UserLogic.GetAllUsers().ToList();
            _UserLogic.DeleteUser(projectId);
            List<User> usersNew = _UserLogic.GetAllUsers().ToList();

            Assert.IsNotNull(usersOld);
            Assert.IsNotNull(usersNew);
            Assert.AreNotEqual(usersOld.Count, usersNew.Count);
            Assert.IsNull(_UserLogic.GetUserByID(projectId));
        }

        [TestMethod]
        public void GetUserByEmail()
        {
            string email = "test@test.com";
            User user = _UserLogic.Login(email);

            Assert.IsNotNull(user);
            Assert.AreEqual(email, user.Email);
        }

        [TestMethod]
        public void UpdateUser()
        {
            int projectId = 1;
            string firstName = "Resy";
            User user = _UserLogic.GetUserByID(projectId);
            string oldFirstName = user.Firstname;
            user.Firstname = firstName;
            _UserLogic.UpdateUser(user);
            User userNew = _UserLogic.GetUserByID(projectId);

            Assert.IsNotNull(user);
            Assert.IsNotNull(userNew);
            Assert.AreNotEqual(firstName, oldFirstName);
            Assert.AreEqual(firstName, userNew.Firstname);
        }
    }
}
