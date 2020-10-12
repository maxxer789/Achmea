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
        public IActionResult Index()
        {
                        List<BivViewModel> vms = ViewModelConverter.BivModelToBivViewModel(Logic.GetBiv());

            return View(vms);
        }
    }
}
