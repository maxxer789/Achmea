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

        private readonly ProjectLogic ProjectLogic;
        private readonly IProject IProject;

        //private readonly BIVLogic BivLogic;
        //private readonly IBIV BivInterface;

        private readonly RequiermentLogic Logic;
        private readonly IRequirement Interface;

        public RequirementController(IConfiguration config)
        {
            IProject = new ProjectDAL();
            ProjectLogic = new ProjectLogic(IProject);

            Interface = new RequiermentDAL();
            AreaInterface = new AspectAreaDAL();

            Logic = new RequiermentLogic(Interface);
            AreaLogic = new AspectAreaLogic(AreaInterface);

            //BIVInterface = new BIVDal(config.GetConnectionString("DefaultConnection"));
            //BivLogic = new BivLogic(BivInterface);
        }

        public IActionResult SaveReqruirementsToProject(ProjectCreateViewModel pvm)
        {
            Project proj = ProjectLogic.MakeNewProject(ViewModelConverter.ProjectViewModelToProjectModel(pvm.Project));

            Logic.SaveReqruirementsToProject(ViewModelConverter.AspectAreaViewModelToESA_AspectModel(pvm.AspectAreas), ViewModelConverter.BivViewModelToBivModel(pvm.Bivs), proj);

            return RedirectToAction("index", "home");
        }

        public IActionResult GetRequirementsFromAreas(List<string> Ids)
        {
            List<EsaAspect> areas = new List<EsaAspect>();
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            foreach(string id in Ids)
            {
                EsaAspect asp = new EsaAspect();
                asp.AspectId = Convert.ToInt32(id);
                areas.Add(asp);

                //get areas by Id
                //Convert.ToInt32(id);
                //areas.Add(AreaLogic.GetAreaById(id));
            }
            //get requirements from areas
            requirements = Logic.getRequiermentsFromAreas(areas).ToList();

            return RedirectToAction("Index", "ESA");
        }
        public IActionResult GetRequirementsFromBIV(List<string> BivIds)
        {
            List<Biv> Bivs = new List<Biv>();
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();

            foreach (string id in BivIds)
            {
                //get Biv by id
                //Convert.ToInt32(id);
                //areas.Add(BivLogic.GetBivById(id));
            }

            //get requirements from Biv
            //BivLogic.GetRequirementsFromBiv(Bivs)

            //save requirements to project
            //Logic.SaveReqruirementsToProject(requirements)

            return null;
        }
    }
}