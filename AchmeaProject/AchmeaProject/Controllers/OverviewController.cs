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

namespace AchmeaProject.Controllers
{
    public class OverviewController : Controller
    {
        private readonly IProject Interface;

        public OverviewController(IConfiguration config)
        {
            Interface = new ProjectDAL(config.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            List<ProjectModel> list = Interface.GetProjects();

            List<ProjectViewModel> listModel = new List<ProjectViewModel>();

            foreach (ProjectModel model in list)
            {
                ProjectViewModel viewModel = new ProjectViewModel()
                {
                    Title = model.GetTitle(),
                    Status = model.GetStatus(),
                    CreationDate = model.GetDate().ToShortDateString()
                };
                if(viewModel.CreationDate == "1-1-0001")
                {
                    viewModel.CreationDate = "Unset";
                }
                listModel.Add(viewModel);
            }
            return View(listModel);
        }
    }
}
