using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AchmeaProject.Controllers
{
    public class BaseController : Controller
    {

        public BaseController()
        {
            if (HttpContext != null)
            {
                if (HttpContext.Session.GetInt32("UserID") != null)
                {
                    ViewBag.User = HttpContext.Session.GetString("UserID");
                }
            }

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}