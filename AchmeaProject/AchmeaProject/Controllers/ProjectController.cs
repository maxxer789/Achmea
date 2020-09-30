using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using AchmeaProject.Database;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using Achmea.Core.Interface;

namespace AchmeaProject.Controllers
{
    public class ProjectController : Controller
    {
        ProjectDAL projectDAL;
        ProjectLogic projectLogic;


        public ProjectController()
        {
            projectDAL = new ProjectDAL();
            projectLogic = new ProjectLogic(projectDAL);
        }

        public IActionResult CreateProject(string ProjectTitle, string ProjectDescription)
        {
            ProjectModel projectModel = new ProjectModel(1, 1, ProjectTitle, ProjectDescription, "In Progress");
            bool ProjectMade;

            try
            {
                projectLogic.MakeNewProject(projectModel);
                ProjectMade = true;
            }
            catch
            {
                ProjectMade = false;
            }

            if(ProjectMade == true)
            {
                ViewBag.ProjectMade = "Project was made succesfully";
            }

            return RedirectToAction("Index", "Home");

        }

    }
}
