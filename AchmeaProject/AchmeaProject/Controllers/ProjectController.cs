using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using Achmea.Core.Interface;
using AchmeaProject.Models;

namespace AchmeaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ProjectDAL projectDAL;
        ProjectLogic projectLogic;


        public ProjectController()
        {
            projectDAL = new ProjectDAL();
            projectLogic = new ProjectLogic(projectDAL);
        }

        //[HttpGet("{search}")]
        //public List<ProjectModel> Search(string SearchTerm)
        //{
        //    List<ProjectModel> result;
            
        //    try
        //    {
        //        result = projectDAL.Search(SearchTerm);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.ToString());
        //    }

        //    return result;

        //}

        public IActionResult CreateProject(string ProjectTitle, string ProjectDescription)
        {
            Project projectModel = new Project(1, 1, ProjectTitle, ProjectDescription, "In Progress");
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

            //if(ProjectMade == true)
            //{
            //    ViewBag.ProjectMade = "Project was made succesfully";
            //}

            return RedirectToAction("Index", "Home");

        }

    }
}
