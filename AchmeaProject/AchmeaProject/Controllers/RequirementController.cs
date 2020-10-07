using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achmea.Core;
using Achmea.Core.Logic;
using Achmea.Core.Model;
using Achmea.Core.Interface;
using Microsoft.Extensions.Configuration;
using Achmea.Core.SQL;
using AchmeaProject.Models;
using AchmeaProject.Models.ViewModelConverter;

namespace AchmeaProject.Controllers
{
    public class RequirementController : Controller
    {
        private readonly AspectAreaLogic AreaLogic;
        private readonly IAspectArea AreaInterface;

        private readonly RequiermentLogic Logic;
        private readonly IRequirement Interface;

        public RequirementController(IConfiguration config)
        {
            Interface = new RequiermentDAL(config.GetConnectionString("DefaultConnection"));
            AreaInterface = new AspectAreaDAL(config.GetConnectionString("DefaultConnection"));
            Logic = new RequiermentLogic(Interface);
            AreaLogic = new AspectAreaLogic(AreaInterface);
        }

        [HttpPost]
        public IActionResult GetRequirementsFromAreas(List<string> Ids)
        {
            List<AspectAreaModel> Areas = new List<AspectAreaModel>();
            foreach(string id in Ids)
            {
                AspectAreaModel aam = AreaLogic.GetAspectAreaById(Convert.ToInt32(id));
                Areas.Add(aam);
            }
            List<RequirementModel> requirements = Logic.getRequiermentsFromAreas(Areas);
            return RedirectToAction("Index", "ESA");
        }
    }
}