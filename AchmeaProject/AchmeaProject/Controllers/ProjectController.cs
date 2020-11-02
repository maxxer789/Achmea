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
using AchmeaProject.Models.ViewModelConverter;

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

        public IActionResult CreateProject(ProjectCreateViewModel pvm)
        {
            bool ProjectMade;

            try
            {
                projectLogic.MakeNewProject(ViewModelConverter.ProjectViewModelToProjectModel(pvm.Project));
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

            return RedirectToAction("SaveReqruirementsToProject", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UserID") == null)
            {
                Response.WriteAsync("<script language='javascript'>window.alert('Please login to create a new project');window.location.href='/User/Login';</script>");
                return RedirectToAction("Login", "User", null);
            }

            ProjectCreateViewModel vm = new ProjectCreateViewModel
            {
                Project = new ProjectCreationDetailsViewModel()
                {
                    UserID = HttpContext.Session.GetInt32("UserID").Value,
                    CreationDate = DateTime.Now.ToShortDateString()
                }
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(ProjectCreateViewModel vm)
        {
            return View(vm);
        }
    }
}
