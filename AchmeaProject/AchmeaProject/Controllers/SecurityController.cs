using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.SQL;
using AchmeaProject.Models;
using AchmeaProject.Models.ViewModelConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AchmeaProject.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IProject IProject;
        private readonly UserLogic UserLogic;
        private readonly ProjectLogic ProjectLogic;
        private readonly IUser IUser;
        private readonly IRequirement IRequirement;

        public SecurityController(IConfiguration config)
        {
            IProject = new ProjectDAL();
            IUser = new UserDAL();
            UserLogic = new UserLogic(IUser);
            ProjectLogic = new ProjectLogic(IProject);
            IRequirement = new RequirementDAL();
        }

        public IActionResult Index()
        {
            return View("Views/Accounts/Security/Index.cshtml");
        }

        public IActionResult ProjectList()
        {
            if (HttpContext.Session.GetString("RoleID") == "Security")
            {
                List<Project> list = IProject.GetProjects().ToList();

                List<ProjectViewModel> vmList = new List<ProjectViewModel>();

                foreach (Project model in list)
                {
                    ProjectViewModel viewModel = new ProjectViewModel()
                    {
                        ProjectId = model.ProjectId,
                        Title = model.Title,
                        Description = model.Description,
                        CreationDate = model.CreationDate?.ToString("d")
                    };
                    vmList.Add(viewModel);
                }
                return View("Views/Accounts/Security/ProjectView.cshtml", vmList);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int projectId)
        {
            if (HttpContext.Session.GetString("RoleID") == "Security")
            {
                Project project = IProject.GetProject(projectId);

                ProjectDetailViewModel vm = new ProjectDetailViewModel()
                {
                    ProjectId = project.ProjectId,
                    UserId = project.UserId,
                    Title = project.Title,
                    Description = project.Description,
                    CreationDate = project.CreationDate?.ToString("d"),
                    EsaAspects = ProjectLogic.GetEsaForProject(projectId),
                    RequirementProject = ProjectLogic.GetRequirementsForProject(projectId),
                    Requirements = IRequirement.GetAllRequirements(),
                    User = UserLogic.GetUserByID(project.UserId)
                };

                return View("Views/Accounts/Security/Details.cshtml", vm);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult updateStatus(int projectId)
        {
            return Index();
        }
    }
}