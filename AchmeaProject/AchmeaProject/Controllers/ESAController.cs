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
    public class ESAController : BaseController
    {
        private readonly AspectAreaLogic _AspectAreaLogic;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ESAController(IConfiguration config, IHttpContextAccessor httpContextAccessor, IAspectArea iAspectArea)
        {
            _AspectAreaLogic = new AspectAreaLogic(iAspectArea);
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Select()
        {
            if (HttpContext.Session.GetString("RoleID") == "Developer")
            {
                if (_session.GetObjectFromJson<ProjectCreateViewModel>("Project") == null)
                {
                    RedirectToAction("Create", "Project");
                }

                ProjectCreateViewModel vm = _session.GetObjectFromJson<ProjectCreateViewModel>("Project");

                if (vm.AspectAreas.Count == 0)
                {
                    vm.AspectAreas = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(_AspectAreaLogic.GetAspectAreas());
                }

                return View(vm);

            }else if(HttpContext.Session.GetString("RoleID") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "User");
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
