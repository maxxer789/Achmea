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
            Interface = new AspectAreaDAL(config.GetConnectionString("MSSQLfhict"));
            Logic = new AspectAreaLogic(Interface);
        }

        public IActionResult Index()
        {
            List<ESA_AspectViewModel> vms = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas());

            return View(vms);
        }
    }
}
