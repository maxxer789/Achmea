using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using Achmea.Core.Interface;

namespace AchmeaProject.Controllers
{
    public class RequirementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}