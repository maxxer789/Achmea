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
using AchmeaProject.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace AchmeaProject.Controllers
{
    public class ESAController : Controller
    {
        private readonly AspectAreaLogic Logic;
        private readonly IAspectArea Interface;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ESAController(IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            Interface = new AspectAreaDAL();
            Logic = new AspectAreaLogic(Interface);
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Select()
        {
            if (_session.GetObjectFromJson<ProjectCreateViewModel>("Project") == null)
            {
                RedirectToAction("Create", "Project");
            }

            ProjectCreateViewModel vm = _session.GetObjectFromJson<ProjectCreateViewModel>("Project");

            if (vm.AspectAreas.Count == 0)
            {
                vm.AspectAreas = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas());
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Select(ProjectCreateViewModel vm, string submitButton)
        {
            if (vm.AspectAreas.Count(e => e.isSelected == true) == 0 && submitButton == "next")
            {
                ModelState.AddModelError(string.Empty, "Please select atleast one applicable aspect area");
                return View(vm);
            }

            _session.Update("Project", vm);

            if (submitButton == "next")
            {
                return RedirectToAction("Select", "Biv");
            }
            if (submitButton == "back")
            {
                return RedirectToAction("Create", "Project");
            }

            return View(vm);
        }
    }
}
