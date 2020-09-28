using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Achmea.Core.Model;
using AchmeaProject.Models;

namespace AchmeaProject.Controllers
{
    public class OverviewController : Controller
    {
        public IActionResult Index()
        {
            List<ProjectViewModel> listModel = new List<ProjectViewModel>();
            ProjectModel project = new ProjectModel(1, 2, "test", "Kijk hoe mooi dit is wauw.", "Incomplete");
            ProjectViewModel model = new ProjectViewModel()
            {
                Title = project.GetTitle(),
                Owner = project.GetUser().ToString(),
                Status = project.GetStatus()
            };
            listModel.Add(model);
            ProjectModel project2 = new ProjectModel(3, 4, "test2", "Ziet er goed uit.", "Complete");
            ProjectViewModel model2 = new ProjectViewModel()
            {
                Title = project2.GetTitle(),
                Owner = project2.GetUser().ToString(),
                Status = project2.GetStatus()
            };
            listModel.Add(model2);
            return View(listModel);
        }
    }
}
