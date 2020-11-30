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
        private readonly RequirementLogic _RequirementLogic;
        private readonly UserLogic _UserLogic;
        private readonly ProjectLogic _ProjectLogic;

        public SecurityController(IConfiguration config, IProject iProject, IUser iUser, IRequirement iRequirement)
        {
            _UserLogic = new UserLogic(iUser);
            _ProjectLogic = new ProjectLogic(iProject);
            _RequirementLogic = new RequirementLogic(iRequirement);
        }

        public IActionResult Index()
        {
            return View("Views/Accounts/Security/Index.cshtml");
        }

        public IActionResult ProjectList()
        {
            if (HttpContext.Session.GetString("RoleID") == "Security")
            {
                List<Project> list = _ProjectLogic.GetProjects().ToList();

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
                Project project = _ProjectLogic.GetProject(projectId);

                ProjectDetailViewModel vm = new ProjectDetailViewModel()
                {
                    ProjectId = project.ProjectId,
                    UserId = project.UserId,
                    Title = project.Title,
                    Description = project.Description,
                    CreationDate = project.CreationDate?.ToString("d"),
                    RequirementProject = _ProjectLogic.GetRequirementsForProject(projectId),
                    Requirements = _RequirementLogic.GetAllRequirements(),
                    User = _UserLogic.GetUserByID(project.UserId)
                };

                return View("Views/Accounts/Security/Details.cshtml", vm);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult UpdateRequirementStatus(bool Approved, int ProjectId, int ReqId)
        {
            SecurityRequirementProject req = _ProjectLogic.GetRequirementsForProject(ProjectId).Where(x => x.SecurityRequirementProjectId == ReqId).SingleOrDefault();
            if (Approved)
            {
                _Status status = _Status.Approved;
                _RequirementLogic.UpdateRequirentStatus(req, status);
            }
            else
            {
                _Status status = _Status.Declined;
                _RequirementLogic.UpdateRequirentStatus(req, status);
            }

            return RedirectToAction("Details", new { projectId = ProjectId });
        }
    }
}