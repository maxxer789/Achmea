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
                new ESA_AspectViewModel(2, "ESA2", "ESA Description 2"),
                new ESA_AspectViewModel(3, "ESA3", "ESA Description 3"),
                new ESA_AspectViewModel(4, "ESA4", "ESA Description 4"),
                new ESA_AspectViewModel(5, "ESA5", "ESA Description 5"),
                new ESA_AspectViewModel(6, "ESA6", "ESA Description 6"),
                new ESA_AspectViewModel(7, "ESA7", "ESA Description 7"),
                new ESA_AspectViewModel(8, "ESA8", "ESA Description 8"),
                new ESA_AspectViewModel(9, "ESA9", "ESA Description 9"),
                new ESA_AspectViewModel(10, "ESA10", "ESA Description 10"),
                new ESA_AspectViewModel(11, "ESA11", "ESA Description 11"),
                new ESA_AspectViewModel(12, "ESA12", "ESA Description 12")
            };

            return View(vms);
        }
    }
}
