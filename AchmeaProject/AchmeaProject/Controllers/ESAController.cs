using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AchmeaProject.Controllers
{
    public class ESAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
