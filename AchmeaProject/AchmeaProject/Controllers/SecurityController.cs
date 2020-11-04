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
            List<Project> list = IProject.GetProjects().ToList();

            List<ProjectViewModel> vmList = new List<ProjectViewModel>();

            foreach (Project model in list)
            {
                ProjectViewModel viewModel = new ProjectViewModel()
                {
                    ProjectId = model.ProjectId,
                    Title = model.Title,
                    Status = model.Status,
                };
                if (viewModel.CreationDate == "1-1-0001")
                {
                    viewModel.CreationDate = "Unset";
                }
                vmList.Add(viewModel);
            }
            return View("Views/Accounts/Security/ProjectView.cshtml", vmList);
        }

        public IActionResult Details(int projectId)
        {
            Project P = IProject.GetProject(projectId);

            ProjectDetailViewModel vm = new ProjectDetailViewModel()
            {
                ProjectId = P.ProjectId,
                Title = P.Title,
                Status = P.Status,
                UserId = P.UserId,
                Description = P.Description,
                CreationDate = P.CreationDate.ToString(),
                EsaAspects = IProject.GetEsaForProject(projectId),
                RequirementProject = IProject.GetRequirementsForProject(projectId),
                Requirements = IRequirement.GetAllRequirements()
            };

            return View("Views/Accounts/Security/Details.cshtml", vm);
        }
    }
}