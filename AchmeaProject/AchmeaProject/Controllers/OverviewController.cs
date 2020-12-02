﻿using System;
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
using Microsoft.AspNetCore.Hosting;
using Google.Apis.Drive.v3;

namespace AchmeaProject.Controllers
{
    public class OverviewController : Controller
    {
        private readonly ProjectLogic _ProjectLogic;
        private readonly RequirementLogic _RequirementLogic;
        private readonly UserLogic _UserLogic;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DriveService service;

        public OverviewController(IWebHostEnvironment webHost, IConfiguration config, IProject iProject, IRequirement iRequirement, IUser iUser)
        {
            _ProjectLogic = new ProjectLogic(iProject);
            _RequirementLogic = new RequirementLogic(iRequirement);
            _UserLogic = new UserLogic(iUser);

            _webHostEnvironment = webHost;
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string serviceAccountEmail = config.GetSection("ServiceAccountGoogleDrive:ServiceAccountEmail").Value;
            service = GoogleDriveConnection.GetDriveService(webRootPath, contentRootPath, serviceAccountEmail);
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

                ProjectDetailViewModel model = new ProjectDetailViewModel()
                {
                    ProjectId = project.ProjectId,
                    UserId = project.UserId,
                    Title = project.Title,
                    Description = project.Description,
                    CreationDate = project.CreationDate?.ToString("d"),
                    RequirementProject = _ProjectLogic.GetRequirementsForProject(projectId),
                    Requirements = _RequirementLogic.GetAllRequirements(),
                    User = _UserLogic.GetUserByID(project.UserId)
                };

                foreach (SecurityRequirementProject item in model.RequirementProject)
                {
                    if (item.FileOfProof != null)
                    {
                        model.Files.Add(GoogleDriveConnection.GetFileById(service, item.FileOfProof.FileLocation));
                    }
                }

                if (TempData["Message"] != null)
                {
                    ViewBag.Message = TempData["Message"].ToString();
                }

                return View(model);
            }
            return RedirectToAction("Login", "User");
        }
    }
}
