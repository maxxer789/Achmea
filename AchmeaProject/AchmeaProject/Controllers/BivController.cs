﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core.Interface;
using Achmea.Core.Logic;
using Achmea.Core.SQL;
using AchmeaProject.Models;
using AchmeaProject.Models.ViewModelConverter;
using AchmeaProject.Sessions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AchmeaProject.Controllers
{
    public class BivController : Controller
    {
        private readonly BivLogic _BivLogic;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public BivController(IConfiguration config, IHttpContextAccessor httpContextAccessor, IBiv iBiv)
        {
            _BivLogic = new BivLogic(iBiv);
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

                if (vm.Bivs.Count == 0)
                {
                    vm.Bivs = ViewModelConverter.BivModelToBivViewModel(_BivLogic.GetBiv());
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
            if (vm.Bivs.Count(e => e.isSelected == true) == 0 && submitButton == "next")
            {
                ModelState.AddModelError(string.Empty, "Selecteer minimaal één BIV classificatie om verder te gaan");
                return View(vm);
            }

            _session.Update("Project", vm);

            if (submitButton == "next")
            {
                return RedirectToAction("ConfirmDetails", "Project");
            }
            if (submitButton == "back")
            {
                return RedirectToAction("Select", "ESA");
            }

            return View(vm);
        }
    }
}
