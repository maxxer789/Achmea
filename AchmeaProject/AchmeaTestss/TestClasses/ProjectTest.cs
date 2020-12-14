using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Models;
using AchmeaTestss.MockServices;
using DeepEqual.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AchmeaTestss.TestClasses
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
            int id = 4;
            int userid = 5;
            string title = "Test project 4";
            string description = "This is the description for test project 4.";

            Project p2 = new Project(id, userid, title, description);
            Project p3 = new Project(id, userid, title, description, DateTime.Now);

            Assert.AreEqual(id, p2.ProjectId);
            Assert.AreEqual(userid, p2.UserId);
            Assert.AreEqual(title, p2.Title);
            Assert.AreEqual(description, p2.Description);

            Assert.AreEqual(id, p3.ProjectId);
            Assert.AreEqual(userid, p3.UserId);
            Assert.AreEqual(title, p3.Title);
            Assert.AreEqual(description, p3.Description);
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
        public void CanGetSingleProject()
        {
            int projectId = 1;
            Project project = _ProjectLogic.GetProject(projectId);

            Assert.IsNotNull(project);
            Assert.AreEqual(projectId, project.ProjectId);
        }

        [TestMethod]
        public void CanCreateNewProject()
        {
            List<Project> oldProjects = _ProjectLogic.GetProjects();
            Project project = new Project(3, 3, "Test Project 3", "This is the description for test project 3.");
            int[] members = { 1, 2 };

            _ProjectLogic.MakeNewProject(project, members);
            List<Project> newProjects = _ProjectLogic.GetProjects();

            Assert.AreNotEqual(oldProjects, newProjects);
        }

        [TestMethod]
        public void CanGetRequirementsForProject()
        {
            int projectId = 1;
            Project project = _ProjectLogic.GetProject(projectId);
            List<SecurityRequirementProject> requirements = _ProjectLogic.GetRequirementsForProject(projectId);

            Assert.IsNotNull(requirements);
            Assert.AreEqual(project.SecurityRequirementProject.Count, requirements.Count);
        }

        [TestMethod]
        public void CanGetProjectsForUser()
        {
            int userId = 1;
            List<Project> projects = _ProjectLogic.GetProjectsFromUser(userId);
            Project Expected = _ProjectLogic.GetProject(1);

            Assert.AreEqual(projects.Count, 1);
            Assert.IsTrue(projects[0].IsDeepEqual(Expected));
        }

        [TestMethod]
        public void ReturnsEmptyListWhenUserHasNoProjects()
        {
            int userId = 3;
            List<Project> projects = _ProjectLogic.GetProjectsFromUser(userId);

            Assert.AreEqual(projects.Count, 0);
        }

        [TestMethod]
        public void ReturnsEmptyListWhenNoProjectsRequireActions()
        {
            int userId = 1;
            List<Project> ActionList = _ProjectLogic.GetProjectsWithNeededActions(userId);

            Assert.AreEqual(ActionList.Count, 0);
        }

        [TestMethod]
        public void ReturnsActionListForUser()
        {
            int userId = 2;
            List<Project> ActionList = _ProjectLogic.GetProjectsWithNeededActions(userId);
            Project Expected = _ProjectLogic.GetProject(2);

            Assert.AreEqual(ActionList.Count, 1);
            Assert.IsTrue(ActionList[0].IsDeepEqual(Expected));
        }
    }
}
