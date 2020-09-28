using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AchmeaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AchmeaProject.Controllers
{
    public class ESAController : Controller
    {
        public IActionResult Index()
        {
            List<ESA_AspectViewModel> vms = new List<ESA_AspectViewModel>()
            {
                new ESA_AspectViewModel(1, "ESA1", "ESA Description 1"),
                new ESA_AspectViewModel(1, "ESA2", "ESA Description 2"),
                new ESA_AspectViewModel(1, "ESA3", "ESA Description 3"),
                new ESA_AspectViewModel(1, "ESA4", "ESA Description 4"),
                new ESA_AspectViewModel(1, "ESA5", "ESA Description 5"),
                new ESA_AspectViewModel(1, "ESA6", "ESA Description 6")
            };

            return View(vms);
        }
    }
}
