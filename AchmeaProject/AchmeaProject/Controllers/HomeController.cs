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
        UserDAL userDAL;
        private readonly ILogger<HomeController> _logger;
        CommentLogic commentLogic;
        CommentDAL commentDAL;



        public HomeController(ILogger<HomeController> logger)
        {
            commentDAL = new CommentDAL();
            commentLogic = new CommentLogic(commentDAL);
            userDAL = new UserDAL();
            userLogic = new UserLogic(userDAL);
            _logger = logger;
        }



        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("RoleID") != null)
            {

            }
            return RedirectToAction("Login", "User");
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
    }
}