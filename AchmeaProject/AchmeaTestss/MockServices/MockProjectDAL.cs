using Achmea.Core.Interface;
using AchmeaProject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Achmea.Core.Logic;
using System.Linq;

namespace AchmeaTestss.MockServices
{
    public class MockProjectDAL: IProject
    {
        private List<Project> Projects;

        public MockProjectDAL()
        {
            Projects = Populate();
        }

        public List<Project> GetProjectsFromUser(int userId)
        {
            return Projects;
        }

        public List<Project> GetProjectsWithNeededActions(int i)
        {
            return Projects;
        }

        public Project AddNewProject(Project project, int[] MemberIDs)
        {
            Project p = new Project(3, 3, "Test Project 3", "This is the description for test project 3.");
            Projects.Add(p);
            return p;
        }

        public IEnumerable<Project> GetProjects()
        {
            return Projects;
        }

        public Project GetProject(int id)
        {
            return Projects.Where(x => x.ProjectId == id).FirstOrDefault();
        }

        public List<SecurityRequirementProject> GetRequirementsForProject(int id)
        {
            List<SecurityRequirementProject> list = new List<SecurityRequirementProject>();
            foreach(Project project in Projects)
            {
                if(project.ProjectId == id)
                {
                    list.AddRange(project.SecurityRequirementProject);
                }
            }
            return list;
        }

        public void UpdateProjectStatus(Project givenProject)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetProjectsFromUser(int userId)
        {
            List<Project> projects = new List<Project>();
            foreach (Project project in Projects)
            {
                if (project.UserId == userId)
                {
                    projects.Add(project);
                }
            }
            return projects;
        }
        public List<Project> GetProjectsWithNeededActions(int userId)
        {
            List<Project> projects = GetProjectsFromUser(userId);
            List<Project> ActionList = new List<Project>();
            foreach (Project project in projects)
            {
                if (project.SecurityRequirementProject.Any(p => p.Status == Achmea.Core.Logic._Status.Declined || p.Status == Achmea.Core.Logic._Status.Under_review))
                {
                    ActionList.Add(project);
                }
            }

            return ActionList;
        }

        public List<Project> Populate()
        {
            List<Project> list = new List<Project>();

            list.Add(new Project()
            {
                ProjectId = 1,
                UserId = 1,
                Title = "Test Project 1",
                Description = "This is the description for test project 1.",
                CreationDate = DateTime.Now,
                User = new User()
                {
                    UserId = 1,
                    Email = "testuser1@test.com",
                    Password = "Password1",
                    Firstname = "Firstname1",
                    Lastname = "Lastname1",
                    PhoneNumber = 0612345678,
                    RoleId = "Developer"
                },
                SecurityRequirementProject = new List<SecurityRequirementProject>
                {
                    new SecurityRequirementProject()
                    {
                        SecurityRequirementProjectId = 1,
                        ProjectId = 1,
                        SecurityRequirementId = 1,
                        Excluded = false,
                        Status = _Status.Submit_evidence,
                        SecurityRequirement = new SecurityRequirement()
                        {
                            RequirementId = 1,
                            Name = "Test Requirement 1",
                            Description = "Description for test requirement 1",
                            Details = "Details for test requirement 1",
                            Family = "TE",
                            RequirementNumber = "TE01",
                            MainGroup = "1. Testing"
                        }
                    },
                    new SecurityRequirementProject()
                    {
                        SecurityRequirementProjectId = 2,
                        ProjectId = 1,
                        SecurityRequirementId = 2,
                        Excluded = false,
                        Status = _Status.Submit_evidence,
                        SecurityRequirement = new SecurityRequirement()
                        {
                            RequirementId = 2,
                            Name = "Test Requirement 2",
                            Description = "Description for test requirement 2",
                            Details = "Details for test requirement 2",
                            Family = "TE",
                            RequirementNumber = "TE02",
                            MainGroup = "1. Testing"
                        }
                    }
                }
            });
            list.Add(new Project()
            {
                ProjectId = 2,
                UserId = 2,
                Title = "Test Project 2",
                Description = "This is the description for test project 2.",
                CreationDate = DateTime.Now,
                User = new User()
                {
                    UserId = 2,
                    Email = "testuser2@test.com",
                    Password = "Password2",
                    Firstname = "Firstname2",
                    Lastname = "Lastname2",
                    PhoneNumber = 0687654321,
                    RoleId = "Developer"
                },
                SecurityRequirementProject = new List<SecurityRequirementProject>
                {
                    new SecurityRequirementProject()
                    {
                        SecurityRequirementProjectId = 3,
                        ProjectId = 2,
                        SecurityRequirementId = 3,
                        Excluded = false,
                        Status = _Status.Submit_evidence,
                        SecurityRequirement = new SecurityRequirement()
                        {
                            RequirementId = 3,
                            Name = "Test Requirement 3",
                            Description = "Description for test requirement 3",
                            Details = "Details for test requirement 3",
                            Family = "TE",
                            RequirementNumber = "TE03",
                            MainGroup = "1. Testing"
                        }
                    },
                    new SecurityRequirementProject()
                    {
                        SecurityRequirementProjectId = 4,
                        ProjectId = 2,
                        SecurityRequirementId = 4,
                        Excluded = false,
                        Status = _Status.Submit_evidence,
                        SecurityRequirement = new SecurityRequirement()
                        {
                            RequirementId = 4,
                            Name = "Test Requirement 4",
                            Description = "Description for test requirement 4",
                            Details = "Details for test requirement 4",
                            Family = "TE",
                            RequirementNumber = "TE04",
                            MainGroup = "1. Testing"
                        }
                    },
                    new SecurityRequirementProject()
                    {
                        SecurityRequirementProjectId = 5,
                        ProjectId = 2,
                        SecurityRequirementId = 5,
                        Excluded = false,
                        Status = _Status.Declined,
                        SecurityRequirement = new SecurityRequirement()
                        {
                            RequirementId = 5,
                            Name = "Test Requirement 5",
                            Description = "Description for test requirement 5",
                            Details = "Details for test requirement 5",
                            Family = "TE",
                            RequirementNumber = "TE05",
                            MainGroup = "1. Testing"
                        }
                    },
                                        new SecurityRequirementProject()
                    {
                        SecurityRequirementProjectId = 6,
                        ProjectId = 2,
                        SecurityRequirementId = 6,
                        Excluded = false,
                        Status = _Status.Under_review,
                        SecurityRequirement = new SecurityRequirement()
                        {
                            RequirementId = 6,
                            Name = "Test Requirement 6",
                            Description = "Description for test requirement 6",
                            Details = "Details for test requirement 6",
                            Family = "TE",
                            RequirementNumber = "TE06",
                            MainGroup = "1. Testing"
                        }
                    }
                }
            });
            return list;
        }
    }
}
