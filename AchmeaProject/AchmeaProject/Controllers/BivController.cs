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
    public class BivController : Controller
    {
        private readonly BivLogic Logic;
        private readonly IBiv Interface;

        public BivController(IConfiguration config)
        {
            Interface = new BivDAL();
            Logic = new BivLogic(Interface);
        }

        [HttpPost]
        public IActionResult Select(ProjectCreateViewModel vm)
        {
            vm.Bivs = ViewModelConverter.BivModelToBivViewModel(Logic.GetBiv());

            return View(vm);
        }

        [HttpPost]
        public IActionResult Example(ProjectCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Bivs.Count > 0)
                {
                    return View(vm);
                }
                else
                {
                    ViewBag.Error = TempData["Please select atleast one Aspect area"];
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
