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

        private readonly BivLogic BivLogic;
        private readonly IBiv BivInterface;

        private readonly RequirementLogic Logic;
        private readonly IRequirement Interface;

        public RequirementController(IConfiguration config)
        {
            IProject = new ProjectDAL();
            ProjectLogic = new ProjectLogic(IProject);

            Interface = new RequirementDAL();
            AreaInterface = new AspectAreaDAL();

            Logic = new RequirementLogic(Interface);
            AreaLogic = new AspectAreaLogic(AreaInterface);

            BivInterface = new BivDAL();
            BivLogic = new BivLogic(BivInterface);
        }

        public IActionResult SaveReqruirementsToProject(ProjectCreateViewModel pvm)
        {
            Project proj = ProjectLogic.MakeNewProject(ViewModelConverter.ProjectViewModelToProjectModel(pvm.Project));

            List<Biv> classifications = ViewModelConverter.BivViewModelToBivModel(pvm.Bivs.Where(c => c.isSelected == true).ToList());
            List<EsaAspect> aspects = ViewModelConverter.AspectAreaViewModelToESA_AspectModel(pvm.AspectAreas.Where(a => a.isSelected == true).ToList());

            BivLogic.SaveBivToProject(classifications, proj);
            //AreaLogic.SaveAspectToProject(aspects, proj)

            Logic.SaveReqruirementsToProject(aspects, classifications, proj);

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

        [HttpGet]
        public IActionResult Add()
        {
            string[] families = { "AC", "AT", "AU", "CA", "CM", "CP", "DT", "IA", "LR", "MA", "NW", "PE", "PS", "SA", "SC", "SI" };
            string[] Groups = {  "5. Informatiebeveiligingsbeleid", "6. Organiseren van informatiebeveiliging", "7. Veilig personeel", "8. Beheer van bedrijfsmiddelen",
                            "9. Toegangsbeveiliging", "10. Cryptografie", "11. Fysieke beveiliging en beveiliging van de omgeving", "12. Beveiliging bedrijfsvoering",
                            "13. Communicatiebeveiliging", "14. Acquisitie, ontwikkeling en onderhoud van informatiesystemen", "15. Leveranciersrelaties", "18. Naleving"};
            ViewBag.Bivs = BivLogic.GetBiv();
            ViewBag.Areas = AreaLogic.GetAreas();
            ViewBag.Families = families;
            ViewBag.Groups = Groups;
            return View();
        }

        public IActionResult Create(RequirementCreateViewModel rcvm)
        {
            if(!(rcvm.BivIds == null || rcvm.AreaIds == null || rcvm.Description == null || rcvm.Details == null || rcvm.Family == null || rcvm.MainGroup == null || rcvm.Name == null || rcvm.RequirementNumber == null))
            {
                List<int> bivIds = new List<int>();
                List<int> areaIds = new List<int>();
                bool hasB = false;
                bool hasI = false; 
                bool hasV = false;
                int lowestB = 3;
                int lowestI = 6;
                int lowestV = 9;

                List<Biv> bivs = BivLogic.GetBiv();

                foreach (string id in rcvm.AreaIds)
                {
                    areaIds.Add(Convert.ToInt32(id));
                }
                foreach (string id in rcvm.BivIds)
                {
                    bivIds.Add(Convert.ToInt32(id));
                }

                bivs = bivs.Where(b => bivIds.Any(id => Convert.ToInt32(id) == b.Id)).ToList();

                foreach(Biv b in bivs)
                {
                    if (b.Name.First().ToString() == "b")
                    {
                        hasB = true;
                        if (b.Id < lowestB) lowestB = b.Id;
                    }
                    if (b.Name.First().ToString() == "i") 
                    { 
                        hasI = true;
                        if (b.Id < lowestI) lowestI = b.Id;
                    }
                    if (b.Name.First().ToString() == "v")
                    {
                        hasV = true;
                        if (b.Id < lowestV) lowestV = b.Id;
                    }
                }
                bivIds.Clear();
                bivIds.Add(lowestB);
                bivIds.Add(lowestI);
                bivIds.Add(lowestV);
                SecurityRequirement req = ViewModelConverter.securityRequirementViewModelToModel(rcvm);

                if(hasB && hasI && hasV)
                {
                    Logic.CreateRequirement(req, bivIds, areaIds);
                }
            }

            return RedirectToAction("Add");
        }
    }
}