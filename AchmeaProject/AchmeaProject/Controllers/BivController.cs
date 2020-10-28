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
            if (vm.AspectAreas.Count(e => e.isSelected == true) == 0)
            {
                ModelState.AddModelError(string.Empty,"Please select atleast one applicable aspect area");

                return View("Views/ESA/Select.cshtml", vm);
            }


            vm.Bivs = ViewModelConverter.BivModelToBivViewModel(Logic.GetBiv());

            return View(vm);
        }

        [HttpPost]
        public IActionResult Example(ProjectCreateViewModel vm)
        {
            if (vm.Bivs.Count(e => e.isSelected == true) == 0)
            {
                ModelState.AddModelError(string.Empty, "Please select atleast one applicable biv classification");

                return View("Views/BIV/Select.cshtml", vm);
            }

            return View(vm);
        }
    }
}
