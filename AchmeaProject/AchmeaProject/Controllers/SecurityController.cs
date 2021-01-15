using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using Achmea.Core.ContextModels;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.SQL;
using AchmeaProject.Hubs;
using AchmeaProject.Models;
using AchmeaProject.Models.ViewModelConverter;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace AchmeaProject.Controllers
{
    public class SecurityController : BaseController
    {
        private readonly RequirementLogic _RequirementLogic;
        private readonly UserLogic _UserLogic;
        private readonly ProjectLogic _ProjectLogic;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DriveService service;
        private readonly UserLogic userLogic;
        private readonly CommentLogic commentLogic;
        private readonly IHubContext<CommentHub> _commentHub;
        CommentHub comment;

        public SecurityController(IWebHostEnvironment webHost, IConfiguration config, IProject iProject, IUser iUser, IRequirement iRequirement, IComment iComment, [NotNull] IHubContext<CommentHub> commentHub)
        {
            _UserLogic = new UserLogic(iUser);
            _ProjectLogic = new ProjectLogic(iProject);
            _RequirementLogic = new RequirementLogic(iRequirement);
            commentLogic = new CommentLogic(iComment);
            userLogic = new UserLogic(iUser);
            comment = new CommentHub();
            _commentHub = commentHub;

            _webHostEnvironment = webHost;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string serviceAccountEmail = config.GetSection("ServiceAccountGoogleDrive:ServiceAccountEmail").Value;
            service = GoogleDriveConnection.GetDriveService(webRootPath, contentRootPath, serviceAccountEmail);
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("RoleID") == "Security")
            {
                return View("Views/Accounts/Security/Index.cshtml");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public IActionResult ProjectList()
        {
            if (HttpContext.Session.GetString("RoleID") == "Security")
            {
                List<Project> list = _ProjectLogic.GetProjects().ToList();

                List<ProjectViewModel> vmList = new List<ProjectViewModel>();

                foreach (Project model in list)
                {
                    ProjectViewModel viewModel = new ProjectViewModel()
                    {
                        ProjectId = model.ProjectId,
                        Title = model.Title,
                        Description = model.Description,
                        CreationDate = model.CreationDate?.ToString("d")
                    };
                    if (_ProjectLogic.GetRequirementsForProject(model.ProjectId).Where(x => x.Status == _Status.Submit_evidence || x.Status == _Status.Declined).FirstOrDefault() != null)
                    {
                        viewModel.Done = false;
                    }
                    else
                    {
                        viewModel.Done = true;
                    }
                    vmList.Add(viewModel);

                }
                return View("Views/Accounts/Security/ProjectView.cshtml", vmList);
            }
            return RedirectToAction("Login", "User");
        }

        public IActionResult Details(int projectId)
        {
            if (HttpContext.Session.GetString("RoleID") == "Security")
            {
                Project project = _ProjectLogic.GetProject(projectId);

                ProjectDetailViewModel vm = new ProjectDetailViewModel()
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

                var comments = commentLogic.GetAllComments();

                List<CommentViewModel> commentViewModels = new List<CommentViewModel>();

                foreach (var comment in comments)
                {
                    CommentViewModel commentViewModel = new CommentViewModel
                    {
                        Message = comment.Content,
                        UserName = userLogic.GetUserByID(comment.UserId).Firstname,
                        ProjectReqId = comment.SecurityRequirementProjectId,
                    };
                    commentViewModels.Add(commentViewModel);
                }

                ViewBag.Comments = commentViewModels;

                foreach (var item in vm.RequirementProject)
                {
                    if (item.FileOfProof != null)
                    {
                        vm.Files.Add(GoogleDriveConnection.GetFileById(service, item.FileOfProof.FileLocation));
                    }
                }

                return View("Views/Accounts/Security/Details.cshtml", vm);
            }
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRequirementStatus(bool Approved, int ProjectId, int ReqId)
        {
            Project project = _ProjectLogic.GetProject(ProjectId);
            List<ProjectMember> projectMembers = _ProjectLogic.GetProjectMembers(ProjectId);
            List<int> members = new List<int>();

            foreach(var member in projectMembers)
            {
                members.Add(member.UserId);
            }

            SecurityRequirementProject req = _ProjectLogic.GetRequirementsForProject(ProjectId).Where(x => x.SecurityRequirementProjectId == ReqId).SingleOrDefault();
            if (Approved)
            {
                _Status status = _Status.Approved;
                _RequirementLogic.UpdateRequirentStatus(req, status);
                await comment.ReqStatusChange(_commentHub, req.Status.ToString(), project.Title, members);
            }
            else
            {
                _Status status = _Status.Declined;
                _RequirementLogic.UpdateRequirentStatus(req, status);
                await comment.ReqStatusChange(_commentHub, req.Status.ToString(), project.Title, members);
            }

            return RedirectToAction("Details", new { projectId = ProjectId });
        }
    }
}