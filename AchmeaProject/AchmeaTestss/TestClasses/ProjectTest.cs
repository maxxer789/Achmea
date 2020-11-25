using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Models;
using AchmeaTestss.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AchmeaTestss
{
    [TestClass]
    public class ProjectTest
    {
        IProject Interface = new MockProjectDAL();
        private readonly ProjectLogic _ProjectLogic;

        public ProjectTest()
        {
            _ProjectLogic = new ProjectLogic(Interface);
        }

        [TestMethod]
        public void ProjectConstructorsWork()
        {
            Project p2 = new Project(4, 4, "Test Project 4", "This is the description for test project 4");
            Project p3 = new Project(4, 4, "Test Project 4", "This is the description for test project 4", DateTime.Now);

            Assert.AreEqual(4, p2.ProjectId);
            Assert.AreEqual(4, p2.UserId);
            Assert.AreEqual("Test Project 4", p2.Title);
            Assert.AreEqual("This is the description for test project 4", p2.Description);

            Assert.AreEqual(4, p3.ProjectId);
            Assert.AreEqual(4, p3.UserId);
            Assert.AreEqual("Test Project 4", p3.Title);
            Assert.AreEqual("This is the description for test project 4", p3.Description);
        }

        [TestMethod]
        public void CanGetAllProjects()
        {
            List<Project> projects = _ProjectLogic.GetProjects();

            Assert.IsNotNull(projects);
            Assert.AreEqual(2, projects.Count);
            Assert.AreEqual(1, projects[0].ProjectId);
            Assert.AreEqual(2, projects[1].ProjectId);
        }

        [TestMethod]
        public void CanCreateNewProject()
        {
            Project project = new Project(3, 3, "Test Project 3", "This is the description for test project 3.");
            int[] members = { 1, 2 };

            _ProjectLogic.MakeNewProject(project, members);
            List<Project> projects = _ProjectLogic.GetProjects();

            Assert.AreEqual(3, projects.Count);
            Assert.AreEqual(project.ProjectId, projects[2].ProjectId);
        }
    }
}
