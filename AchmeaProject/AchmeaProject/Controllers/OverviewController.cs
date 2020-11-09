using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Achmea.Core.Model;
using AchmeaProject.Models;
using Achmea.Core;
using Achmea.Core.Interface;
using Microsoft.Extensions.Configuration;
using Achmea.Core.SQL;

namespace AchmeaProject.Controllers
{
    public class OverviewController : Controller
    {
        private readonly IProject Interface;
        private readonly IRequirement Requirement;
        private readonly IUser UserLogic;

        //delete
        public OverviewController(IConfiguration config)
        {
            Interface = new ProjectDAL(config.GetConnectionString("DefaultConnection"));
            Requirement = new RequirementDAL();
            UserLogic = new UserDAL();
        }

        public IActionResult Index()
        {
            List<Project> list = Interface.GetProjects().ToList(); 

            List<ProjectViewModel> listModel = new List<ProjectViewModel>();

            foreach (Project model in list)
            {
                ProjectViewModel viewModel = new ProjectViewModel()
                {
                    ProjectId = model.ProjectId,
                    Title = model.Title,
                    Status = model.Status,
                    CreationDate = model.CreationDate?.ToString("d")
                };
                if(viewModel.CreationDate == "1-1-0001")
                {
                    viewModel.CreationDate = "Unset";
                }
                listModel.Add(viewModel);
            }
            return View(listModel);
        }

        public IActionResult Details(int projectId)
        {
            Project project = Interface.GetProject(projectId);

            ProjectDetailViewModel model = new ProjectDetailViewModel()
            {
                ProjectId = project.ProjectId,
                UserId = project.UserId,
                Title = project.Title,
                Description = project.Description,
                Status = project.Status,
                CreationDate = project.CreationDate?.ToString("d"),
                EsaAspects = Interface.GetEsaForProject(projectId),
                RequirementProject = Interface.GetRequirementsForProject(projectId),
                Requirements = Requirement.GetAllRequirements(),
                User = UserLogic.GetUserByID(project.UserId)
            };

            return View(model);
        }
    }
}
