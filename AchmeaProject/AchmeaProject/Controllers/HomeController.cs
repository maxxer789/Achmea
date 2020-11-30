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
            var comments = commentLogic.GetAllComments();



            List<CommentViewModel> commentViewModels = new List<CommentViewModel>();

            foreach (var comment in comments)
            {
                CommentViewModel commentViewModel = new CommentViewModel
                {
                    Message = comment.Content,
                    UserName = userLogic.GetUserByID(comment.UserId).Firstname
                };
                commentViewModels.Add(commentViewModel);
            }



            ViewBag.Comments = commentViewModels;



            if (HttpContext.Session.GetString("RoleID") != null)
            {
                ViewBag.Users = userLogic.GetAllUsers();
                return View();
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