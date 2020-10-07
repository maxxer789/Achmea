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
        public IActionResult Index(List<string> Ids)
        {
            if (ModelState.IsValid)
            {
                if (Ids.Count > 0)
                {
                    return RedirectToAction("Test", new { Ids = Ids });
                }
                else
                {
                    ViewBag.Error = TempData["Please select atleast one Aspect area"];
                    return RedirectToAction("Index");
                }     
            }

            else return RedirectToAction("Index");
        }

        public IActionResult Test(List<string> Ids)
        {
            List<int> ids = new List<int>();
            foreach (string id in Ids)
            {
                ids.Add(Convert.ToInt32(id));
            }
            
            List<ESA_AspectViewModel> AspectAreas = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas());
            List<ESA_AspectViewModel> Selected = new List<ESA_AspectViewModel>();
            Selected = AspectAreas.Where(x => ids.Contains(x.ID)).ToList();

            return View("Test", Selected);
        }
    }
}
