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
using Microsoft.AspNetCore.Http;
using Achmea.Core.Logic;

namespace AchmeaProject.Controllers
{
    public class OverviewController : Controller
    {
        private readonly ProjectLogic _ProjectLogic;
        private readonly RequirementLogic _RequirementLogic;
        private readonly UserLogic _UserLogic;
        CommentLogic commentLogic;
        CommentDAL commentDAL;
        private readonly UserLogic userLogic;
        UserDAL userDAL;

        public OverviewController(IConfiguration config, IProject iProject, IRequirement iRequirement, IUser iUser)
        {
            _ProjectLogic = new ProjectLogic(iProject);
            _RequirementLogic = new RequirementLogic(iRequirement);
            _UserLogic = new UserLogic(iUser);
            commentDAL = new CommentDAL();
            commentLogic = new CommentLogic(commentDAL);
            userDAL = new UserDAL();
            userLogic = new UserLogic(userDAL);

        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("RoleID") != null)
            {
                List<Project> list = _ProjectLogic.GetProjects().ToList();

                List<ProjectViewModel> listModel = new List<ProjectViewModel>();

                foreach (Project model in list)
                {
                    ProjectViewModel viewModel = new ProjectViewModel()
                    {
                        ProjectId = model.ProjectId,
                        Title = model.Title,
                        CreationDate = model.CreationDate?.ToString("d")
                    };
                    if (viewModel.CreationDate == "1-1-0001")
                    {
                        viewModel.CreationDate = "Unset";
                    }
                    listModel.Add(viewModel);
                }
                return View(listModel);
            }
            return RedirectToAction("Login", "User");
        }

        public IActionResult Details(int projectId)
        {
            if (HttpContext.Session.GetString("RoleID") != null)
            {
                Project project = _ProjectLogic.GetProject(projectId);


                var comments = commentLogic.GetAllComments();



                List<CommentViewModel> commentViewModels = new List<CommentViewModel>();

                foreach (var comment in comments)
                {
                    CommentViewModel commentViewModel = new CommentViewModel
                    {
                        Message = comment.Content,
                        UserName = userLogic.GetUserByID(comment.UserId).Firstname,
                        ProjectReqId = comment.SecurityRequirementProjectId,
                        PostDateTime = comment.PostDateTime
                    };
                    commentViewModels.Add(commentViewModel);
                }

                ViewBag.Comments = commentViewModels;

                ProjectDetailViewModel model = new ProjectDetailViewModel()
                {
                    ProjectId = project.ProjectId,
                    UserId = project.UserId,
                    Title = project.Title,
                    Description = project.Description,
                    CreationDate = project.CreationDate?.ToString("d"),
                    RequirementProject = _ProjectLogic.GetRequirementsForProject(projectId),
                    Requirements = _RequirementLogic.GetAllRequirements(),
                    Users = _UserLogic.GetMembersByProjectId(project.UserId)
                };

                return View(model);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
