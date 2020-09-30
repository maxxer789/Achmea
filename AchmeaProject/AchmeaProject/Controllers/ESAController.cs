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
            //List<ESA_AspectViewModel> vms = new List<ESA_AspectViewModel>()
            //{
            //    new ESA_AspectViewModel(1, "ESA1", "ESA Description 1"),
            //    new ESA_AspectViewModel(2, "ESA2", "ESA Description 2"),
            //    new ESA_AspectViewModel(3, "ESA3", "ESA Description 3"),
            //    new ESA_AspectViewModel(4, "ESA4", "ESA Description 4"),
            //    new ESA_AspectViewModel(5, "ESA5", "ESA Description 5"),
            //    new ESA_AspectViewModel(6, "ESA6", "ESA Description 6"),
            //    new ESA_AspectViewModel(7, "ESA7", "ESA Description 7"),
            //    new ESA_AspectViewModel(8, "ESA8", "ESA Description 8"),
            //    new ESA_AspectViewModel(9, "ESA9", "ESA Description 9"),
            //    new ESA_AspectViewModel(10, "ESA10", "ESA Description 10"),
            //    new ESA_AspectViewModel(11, "ESA11", "ESA Description 11"),
            //    new ESA_AspectViewModel(12, "ESA12", "ESA Description 12")
            //};

            List<ESA_AspectViewModel> vms = ViewModelConverter.AspectAreaModelToESA_AspectViewModel(Logic.GetAspectAreas());

            return View(vms);
        }
    }
}
