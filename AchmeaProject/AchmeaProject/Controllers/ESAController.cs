using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.SQL;
using AchmeaProject.Models;
using AchmeaProject.Models.ViewModelConverter;
using Microsoft.AspNetCore.Mvc;
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
            vm.AspectAreas = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas());

            return View(vm);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            ProjectCreateViewModel vm = new ProjectCreateViewModel();
            vm.Project = new ProjectCreationDetailsViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectCreateViewModel vm)
        {
            return View(vm);
        }
    }
}
