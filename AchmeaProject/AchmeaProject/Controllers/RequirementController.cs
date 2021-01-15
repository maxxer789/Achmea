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
using Microsoft.AspNetCore.Http;
using AchmeaProject.Sessions;
using AchmeaProject.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics.CodeAnalysis;

namespace AchmeaProject.Controllers
{
    public class RequirementController : BaseController
    {

        private readonly IHubContext<CommentHub> _commentHub;
        CommentHub comment;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        private readonly AspectAreaLogic _AspectAreaLogic;

        private readonly ProjectLogic _ProjectLogic;

        private readonly BivLogic _BivLogic;

        private readonly RequirementLogic _RequirementLogic;

        public RequirementController(IHttpContextAccessor httpContextAccessor, IProject iProject, IAspectArea iAspectArea, IBiv iBiv, IRequirement iRequirement, [NotNull] IHubContext<CommentHub> commentHub)
        {
            _ProjectLogic = new ProjectLogic(iProject);
            _RequirementLogic = new RequirementLogic(iRequirement);
            _AspectAreaLogic = new AspectAreaLogic(iAspectArea);
            _BivLogic = new BivLogic(iBiv);
            comment = new CommentHub();
            _commentHub = commentHub;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> SaveReqruirementsToProject()
        {
            try
            {
                ProjectCreateViewModel pvm = _session.GetObjectFromJson<ProjectCreateViewModel>("Project");

                Project proj = _ProjectLogic.MakeNewProject(ViewModelConverter.ProjectViewModelToProjectModel(pvm.Project), pvm.Members);

                List<Biv> classifications = ViewModelConverter.BivViewModelToBivModel(pvm.Bivs.Where(c => c.isSelected == true).ToList());
                List<EsaAspect> aspects = ViewModelConverter.AspectAreaViewModelToESA_AspectModel(pvm.AspectAreas.Where(a => a.isSelected == true).ToList());

                _BivLogic.SaveBivToProject(classifications, proj);
                _AspectAreaLogic.SaveAspectToProject(aspects, proj);

                _RequirementLogic.SaveReqruirementsToProject(aspects, classifications, proj);

                if(pvm.Members != null)
                {
                    await comment.projectNotification(_commentHub, proj.Title, pvm.Members);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            _session.Remove("Project");
            return RedirectToAction("index", "home");
        }

        public IActionResult GetRequirementsFromAreas(List<string> Ids)
        {
            List<EsaAspect> areas = new List<EsaAspect>();
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();
            foreach (string id in Ids)
            {
                EsaAspect asp = new EsaAspect();
                asp.AspectId = Convert.ToInt32(id);
                areas.Add(asp);
            }
            requirements = _RequirementLogic.getRequiermentsFromAreas(areas).ToList();

            return RedirectToAction("Index", "ESA");
        }
        public IActionResult GetRequirementsFromBIV(List<string> BivIds)
        {
            List<Biv> Bivs = new List<Biv>();
            List<SecurityRequirement> requirements = new List<SecurityRequirement>();

            foreach (string id in BivIds)
            {
                //get Biv by id
                Convert.ToInt32(id);
                //Bivs.Add(BivLogic.GetBivById(id));
            }

            //get requirements from Biv
            //BivLogic.GetRequirementsFromBiv(Bivs)

            return RedirectToAction("Index" ,"Home");
        }

        [HttpPost]
        public IActionResult ExcludeRequirement(int requirementId, int projectId, string reason)
        {
            _RequirementLogic.ExcludeRequirement(requirementId, projectId, reason);

            return RedirectToAction("Details", "Overview", new { projectId = projectId });
        }

        [HttpGet]
        public IActionResult Add()
        {
            string[] families = { "AC", "AT", "AU", "CA", "CM", "CP", "DT", "IA", "LR", "MA", "NW", "PE", "PS", "SA", "SC", "SI" };
            string[] Groups = {  "5. Informatiebeveiligingsbeleid", "6. Organiseren van informatiebeveiliging", "7. Veilig personeel", "8. Beheer van bedrijfsmiddelen",
                            "9. Toegangsbeveiliging", "10. Cryptografie", "11. Fysieke beveiliging en beveiliging van de omgeving", "12. Beveiliging bedrijfsvoering",
                            "13. Communicatiebeveiliging", "14. Acquisitie, ontwikkeling en onderhoud van informatiesystemen", "15. Leveranciersrelaties", "18. Naleving"};
            ViewBag.Bivs = _BivLogic.GetBiv();
            ViewBag.Areas = _AspectAreaLogic.GetAreas();
            ViewBag.Families = families;
            ViewBag.Groups = Groups;
            return View();
        }

        public IActionResult Create(RequirementCreateViewModel rcvm)
        {
            if (!(rcvm.BivIds == null || rcvm.AreaIds == null || rcvm.Description == null  || rcvm.Family == null || rcvm.MainGroup == null || rcvm.Name == null || rcvm.RequirementNumber == null))
            {
                List<int> bivIds = new List<int>();
                List<int> areaIds = new List<int>();
                int[] bivsa = { 0, 0, 0 };

                List<Biv> bivs = _BivLogic.GetBiv();

                foreach (string id in rcvm.AreaIds)
                {
                    areaIds.Add(Convert.ToInt32(id));
                }
                foreach (string id in rcvm.BivIds)
                {
                    bivIds.Add(Convert.ToInt32(id));
                }

                bivs = bivs.Where(b => bivIds.Any(id => Convert.ToInt32(id) == b.Id)).ToList();

                foreach (Biv b in bivs)
                {
                    if (b.Name.First().ToString() == "b")
                    {
                        if (b.Id < bivsa[0] || bivsa[0] == 0) bivsa[0] = b.Id;
                    }
                    if (b.Name.First().ToString() == "i")
                    {
                        if (b.Id < bivsa[1] || bivsa[1] == 0) bivsa[1] = b.Id;
                    }
                    if (b.Name.First().ToString() == "v")
                    {
                        if (b.Id < bivsa[2] || bivsa[2] == 0) bivsa[2] = b.Id;
                    }
                }
                bivIds.Clear();
                foreach(int i in bivsa)
                {
                    if (i != 0) bivIds.Add(i);
                }
                SecurityRequirement req = ViewModelConverter.securityRequirementViewModelToModel(rcvm);

                _RequirementLogic.CreateRequirement(req, bivIds, areaIds);
            }

            return RedirectToAction("Add");
        }
    }
}