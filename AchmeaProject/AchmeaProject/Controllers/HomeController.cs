using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AchmeaProject.Models;
using Achmea.Core.Logic;
using Achmea.Core.Interface;
using Achmea.Core.SQL;
using Microsoft.AspNetCore.Http;



namespace AchmeaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserLogic userLogic;
        private readonly ProjectLogic projectLogic;
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger, IUser iUser, IProject iPorject)
        {
            projectLogic = new ProjectLogic(iPorject);
            userLogic = new UserLogic(iUser);
            _logger = logger;
        }



        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("RoleID") == null)
            {
                return RedirectToAction("Login", "User");
            }

            return View();

        }



        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("RoleID") != null)
            {
                return View();
            }
            return RedirectToAction("Login", "User");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ToDoList()
        {
            int Userid = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            List<Project> ToDoList = projectLogic.GetProjectsWithNeededActions(Userid);

            return View(ToDoList);
        }
    }
}