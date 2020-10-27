using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using Achmea.Core.Interface;
using AchmeaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AchmeaProject.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IProject Interface;

        public SecurityController(IConfiguration config)
        {
            Interface = new ProjectDAL(config.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            return View("Views/Accounts/Security/Index.cshtml");
        }

        public IActionResult List()
        {
            List<Project> list = Interface.GetProjects().ToList();

            List<ProjectViewModel> listModel = new List<ProjectViewModel>();

            foreach (Project ProjectModel in list)
            {
                ProjectViewModel ProjectVM = new ProjectViewModel()
                {
                    ProjectId = ProjectModel.ProjectId,
                    Title = ProjectModel.Title,
                    Status = ProjectModel.Status,
                    CreationDate = ProjectModel.CreationDate.ToString()
                };
                if (ProjectVM.CreationDate == "1-1-0001")
                {
                    ProjectVM.CreationDate = "Unset";
                }
                listModel.Add(ProjectVM);
            }
            return View(listModel);
        }
    }
}
