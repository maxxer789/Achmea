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
            Interface = new AspectAreaDAL(config.GetConnectionString("MSSQLfhict"));
            Logic = new AspectAreaLogic(Interface);
        }

        public IActionResult Index(ProjectViewModel project)
        {
            AspectSelectViewModel vm = new AspectSelectViewModel()
            {
                project = project,
                AspectAreas = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas())
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(List<int> A)
        {
            if (ModelState.IsValid && A.Count > 0)
            {
                return RedirectToAction("Test", new { selected = A });
            }

            else return RedirectToAction("Index");
        }

        public IActionResult Test(List<int> selected)
        {
            List<ESA_AspectViewModel> AspectAreas = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas());
            List<ESA_AspectViewModel> Selected = new List<ESA_AspectViewModel>();
            Selected = AspectAreas.Where(x => selected.Contains(x.ID)).ToList();

            return View("Test", Selected);
        }
    }
}
