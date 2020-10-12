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
using Microsoft.CodeAnalysis;
using Achmea.Core.Logic;

namespace AchmeaProject.Controllers
{
    public class OverviewController : Controller
    {
        private readonly IProject Interface;
        ProjectLogic projectLogic;
        RequirementLogic requirementLogic;

        public OverviewController(IConfiguration config)
        {
            Interface = new ProjectDAL(config.GetConnectionString("DefaultConnection"));
            projectLogic = new ProjectLogic(Interface);
            requirementLogic = new RequirementLogic();
        }

        public IActionResult Index()
        {
            List<ProjectModel> list = projectLogic.GetProjects();
            List<ProjectViewModel> listModel = new List<ProjectViewModel>();

            foreach (Project model in list)
            {
                ProjectViewModel viewModel = new ProjectViewModel()
                {
                    ProjectId = model.ProjectId,
                    Title = model.Title,
                    Status = model.Status,
                    CreationDate = model.CreationDate.ToString()
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
            ProjectModel project = projectLogic.GetProject(projectId);

            ProjectDetailViewModel model = new ProjectDetailViewModel()
            {
                ProjectId = project.GetProjectId(),
                UserId = project.GetUser(),
                Title = project.GetTitle(),
                Description = project.GetDescription(),
                Status = project.GetStatus(),
                CreationDate = project.GetCreationDate().ToShortDateString(),
                Requirements = requirementLogic.GetRequirementsForProject(projectId),
                Statuses = requirementLogic.GetStatuses(projectId)
            };

            return View(model);
        }
    }
}
