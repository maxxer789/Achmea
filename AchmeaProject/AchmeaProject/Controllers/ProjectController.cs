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
using Microsoft.AspNetCore.Http;
using AchmeaProject.Sessions;
using Achmea.Core.SQL;
using Microsoft.AspNetCore.Mvc.Rendering;
using AchmeaProject.Models.ViewModelConverter;

namespace AchmeaProject.Controllers
{
    //br
    public class ProjectController : Controller
    {
        private readonly ProjectLogic projectLogic;
        private readonly UserLogic userLogic;

        private readonly ISession _session;

        public ProjectController(IHttpContextAccessor httpContextAccessor, IProject iProject, IUser iuser)
        {
            projectLogic = new ProjectLogic(iProject);

            userLogic = new UserLogic(iuser);

            _session = httpContextAccessor.HttpContext.Session;
        }

        //[HttpPost]
        //public ActionResult CreateProject(int[] Members, string ProjectTitle, string ProjectDescription)
        //{
        //    Project projectModel = new Project(1, 1, ProjectTitle, ProjectDescription);
        //    bool ProjectMade;

        //    try
        //    {
        //        var hey = Members;
        //        projectLogic.MakeNewProject(projectModel, Members);
        //        ProjectMade = true;
        //    }
        //    catch
        //    {
        //        ProjectMade = false;
        //    }

        //    if (ProjectMade == true)
        //    {
        //        ViewBag.ProjectMade = "Project was made succesfully";
        //    }

        //    return RedirectToAction("Index", "Home");
        //}

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

            List<User> users = userLogic.GetAllUsers().ToList();
            List<SelectListItem> SelectUsers = new List<SelectListItem>();
            foreach (var user in users)
            {
                SelectUsers.Add(new SelectListItem(user.Firstname + " " + user.Lastname, user.UserId.ToString()));
            }

            ViewBag.Users = ViewModelConverter.UserToUserSelectionViewModel(userLogic.GetAllUsers().ToList());

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ProjectCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Users = ViewModelConverter.UserToUserSelectionViewModel(userLogic.GetAllUsers().ToList());
                return View(vm);
            }

            foreach  (int userid in vm.Members)
            {
                vm.Users.Add(ViewModelConverter.UserToUserSelectionViewModel(userLogic.GetUserByID(userid)));
            }

            _session.SetObjectAsJson("Project", vm);

            return RedirectToAction("Select", "ESA");
        }

        [HttpGet]
        public IActionResult ConfirmDetails()
        {
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
        }
    }
}
