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

namespace AchmeaProject.Controllers
{//test
    public class HomeController : Controller
    {
        private readonly UserLogic userLogic;
        UserDAL userDAL;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            userDAL = new UserDAL();
            userLogic = new UserLogic(userDAL);
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Users = userLogic.GetAllUsers();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
