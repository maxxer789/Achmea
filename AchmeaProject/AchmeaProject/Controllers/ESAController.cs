using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using Achmea.Core.SQL;
using AchmeaProject.Models;
using AchmeaProject.Models.ViewModelConverter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace AchmeaProject.Controllers
{
    public class ESAController : Controller
    {
        private readonly AspectAreaLogic Logic;
        private readonly IAspectArea Interface;

        public ESAController(IConfiguration config)
        {
            Interface = new AspectAreaDAL();
            Logic = new AspectAreaLogic(Interface);
        }

        [HttpPost]
        public IActionResult Select(ProjectCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Views/Project/Create.cshtml", vm);
            }

            vm.AspectAreas = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas());

            return View(vm);
        }
    }
}
