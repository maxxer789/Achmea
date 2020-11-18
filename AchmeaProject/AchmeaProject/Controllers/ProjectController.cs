﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using Achmea.Core.Interface;
using AchmeaProject.Models;
using Microsoft.AspNetCore.Http;
using AchmeaProject.Sessions;
using Achmea.Core.SQL;

namespace AchmeaProject.Controllers
{
    public class ProjectController : Controller
    {
        ProjectLogic projectLogic;

        private readonly UserLogic userLogic;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ProjectController(IHttpContextAccessor httpContextAccessor, IProject iProject)
        {
            projectLogic = new ProjectLogic(iProject);

             userLogic = new UserLogic(new UserDAL());

            _httpContextAccessor = httpContextAccessor;
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
        [HttpPost]
        public ActionResult CreateProject(int[] Members, string ProjectTitle, string ProjectDescription)
        {
            Project projectModel = new Project(1, 1, ProjectTitle, ProjectDescription, "In Progress");
            bool ProjectMade;

            try
            {
                var hey = Members;
                projectLogic.MakeNewProject(projectModel, Members);
                ProjectMade = true;
            }
            catch
            {
                ProjectMade = false;
            }

            if (ProjectMade == true)
            {
                ViewBag.ProjectMade = "Project was made succesfully"; 
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProjectCreateViewModel vm = new ProjectCreateViewModel();

            if (_session.GetObjectFromJson<ProjectCreateViewModel>("Project") != null)
            {
                vm = _session.GetObjectFromJson<ProjectCreateViewModel>("Project");
            }
            else
            {
                vm.Project = new ProjectCreationDetailsViewModel()
                {
                    UserID = HttpContext.Session.GetInt32("UserID").Value
                };
            }

            ViewBag.Users = userLogic.GetAllUsers();

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ProjectCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = userLogic.GetAllUsers();
                return PartialView(vm);
            }

            _session.SetObjectAsJson("Project", vm);

            return Json(Url.Action("Select", "ESA"));
        }

        [HttpGet]
        public IActionResult ConfirmDetails()
        {
            //Change
            if (_session.GetObjectFromJson<ProjectCreateViewModel>("Project") == null)
            {
                return RedirectToAction("Create", "Project");
            }

            ProjectCreateViewModel vm = _session.GetObjectFromJson<ProjectCreateViewModel>("Project");

            return View(vm);
        }

        [HttpPost]
        public IActionResult ConfirmDetails(ProjectCreateViewModel vm)
        {
            if (_session.GetObjectFromJson<ProjectCreateViewModel>("Project") == null)
            {
                return RedirectToAction("Create", "Project");
            }

            if (!ModelState.IsValid)
            {
                if (vm.Bivs.Where(e => e.isSelected == true).ToList().Count == 0 || vm.AspectAreas.Where(e => e.isSelected == true).ToList().Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Please select atleast one aspect area and one BIV classification");
                }

                return View(vm);
            }

            return RedirectToAction("SaveReqruirementsToProject", "Requirement");
            //change
        }
    }
}
