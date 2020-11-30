using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Models;
using AchmeaTestss.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace AchmeaTestss.TestClasses
{
    [TestClass]
    public class RequirementTest
    {
        private IRequirement _IReq;
        private RequirementLogic Logic;

        public RequirementTest()
        {
            _IReq = new MockRequirementDAL();
            Logic = new RequirementLogic(_IReq);
        }

        [TestMethod]
        public void RequirementById_ValidId()
        {
            int Id = 0;

            SecurityRequirement requirement = Logic.GetById(Id);

            Assert.AreEqual(Id, requirement.RequirementId);
        }

        [TestMethod]
        public void RequirementById_InvalidId()
        {
            int Id = 4;

            SecurityRequirement requirement = Logic.GetById(Id);

            Assert.IsNull(requirement);
        }

        [TestMethod]
        public void RequirementConstructorTest()
        {
            string reqName1 = "Requirement1";
            string reqDesc1 = "Description requirement1";
            string reqDet1 = "Extra details description requirement1";
            string reqFamily1 = "AO";
            string reqNum1 = "AO1";
            string reqMain1 = "5. groep 5";

            SecurityRequirement req = new SecurityRequirement(reqName1, reqDesc1, reqDet1, reqFamily1, reqNum1, reqMain1);
            Assert.AreEqual(req.Name, reqName1);
            Assert.AreEqual(req.Description, reqDesc1);
            Assert.AreEqual(req.Details, reqDet1);
            Assert.AreEqual(req.Family, reqFamily1);
            Assert.AreEqual(req.RequirementNumber, reqNum1);
            Assert.AreEqual(req.MainGroup, reqMain1);
        }


        [TestMethod]
        public void GetRequirementFromAspectarea_ValidAspectarea()
        {
            List<EsaAspect> aspectareas = new List<EsaAspect>();

            aspectareas.Add(new EsaAspect()
            {
                AspectId = 0,
            });

            List<SecurityRequirement> requirements = Logic.getRequiermentsFromAreas(aspectareas).ToList();

            Assert.IsNotNull(requirements);
            Assert.IsTrue(requirements.Count > 0);

        }

        [TestMethod]
        public void GetRequirementFromAspectarea_InvalidAspectarea()
        {
            List<EsaAspect> aspectareas = new List<EsaAspect>();

            aspectareas.Add(new EsaAspect()
            {
                AspectId = 191,
            });

            List<SecurityRequirement> requirements = Logic.getRequiermentsFromAreas(aspectareas).ToList();

            Assert.IsNotNull(requirements);
            Assert.IsTrue(requirements.Count == 0);

        }

        [TestMethod]
        public void GetRequirementsFromBiv_ValidBivs()
        {
            List<Biv> classifications = new List<Biv>();

            classifications.Add(new Biv()
            {
                Id = 0
            });

            List<SecurityRequirement> requirements = Logic.getRequiermentsFromBiv(classifications).ToList();

            Assert.IsNotNull(requirements);
            Assert.IsTrue(requirements.Count > 0);
        }

        [TestMethod]
        public void GetRequirementsFromBiv_InvalidBivs()
        {
            List<Biv> classifications = new List<Biv>();

            classifications.Add(new Biv()
            {
                Id = 211
            });

            List<SecurityRequirement> requirements = Logic.getRequiermentsFromBiv(classifications).ToList();

            Assert.IsNotNull(requirements);
            Assert.IsTrue(requirements.Count == 0);
        }

        [TestMethod]
        public void CreateRequirement_RightInfo()
        {
            SecurityRequirement req = new SecurityRequirement("Requirement 4", "Description 4", "", "AO", "AO5", "8");
            List<int> bivIds = new List<int>();
            bivIds.Add(1);
            bivIds.Add(4);
            bivIds.Add(7);
            List<int> areaIds = new List<int>();
            areaIds.Add(1);
            areaIds.Add(2);
            areaIds.Add(3);

            List<SecurityRequirement> initialRequirements = Logic.GetAllRequirements().ToList();

            req = Logic.CreateRequirement(req, bivIds, areaIds);

            Assert.AreNotEqual(initialRequirements.Count, Logic.GetAllRequirements().Count);
            Assert.IsFalse(initialRequirements.Any(requ => requ.RequirementId == req.RequirementId));
            Assert.IsTrue(Logic.GetAllRequirements().Any(requ => requ.RequirementId == req.RequirementId));
        }

        [TestMethod]
        public void CreateRequirement_MissingBivs()
        {
            SecurityRequirement req = new SecurityRequirement("Requirement 4", "Description 4", "", "AO", "AO5", "8");
            List<int> bivIds = new List<int>();
            List<int> areaIds = new List<int>();
            areaIds.Add(1);
            areaIds.Add(2);
            areaIds.Add(3);

            List<SecurityRequirement> initialRequirements = Logic.GetAllRequirements().ToList();

            req = Logic.CreateRequirement(req, bivIds, areaIds);

            Assert.AreEqual(initialRequirements.Count, Logic.GetAllRequirements().Count);
            Assert.IsFalse(req.RequirementId > 0);
        }

        [TestMethod]
        public void CreateRequirement_MissingAreas()
        {
            SecurityRequirement req = new SecurityRequirement("Requirement 4", "Description 4", "", "AO", "AO5", "8");
            List<int> bivIds = new List<int>();
            bivIds.Add(1);
            bivIds.Add(4);
            bivIds.Add(7);
            List<int> areaIds = new List<int>();

            List<SecurityRequirement> initialRequirements = Logic.GetAllRequirements().ToList();

            req = Logic.CreateRequirement(req, bivIds, areaIds);

            Assert.AreEqual(initialRequirements.Count, Logic.GetAllRequirements().Count);
            Assert.IsFalse(req.RequirementId > 0);
        }

        [TestMethod]
        public void CreateRequirement_MissingInfo()
        {
            SecurityRequirement req = new SecurityRequirement("Requirement 4", "", "Details 4", "AO", "AO5", "8");
            List<int> bivIds = new List<int>();
            bivIds.Add(1);
            bivIds.Add(4);
            bivIds.Add(7);
            List<int> areaIds = new List<int>();
            areaIds.Add(1);
            areaIds.Add(2);
            areaIds.Add(3);

            List<SecurityRequirement> initialRequirements = Logic.GetAllRequirements().ToList();

            req = Logic.CreateRequirement(req, bivIds, areaIds);

            Assert.AreEqual(initialRequirements.Count, Logic.GetAllRequirements().Count);
            Assert.IsFalse(req.RequirementId > 0);
        }

        [TestMethod]
        public void SaveRequirementsToProject_RightInfo()
        {
            Project project = new Project()
            {
                ProjectId = 0,
            };
            List<Biv> bivs = new List<Biv>();
            bivs.Add(new Biv()
            {
                Id= 1,
                Name = "B1"
            });
            bivs.Add(new Biv()
            {
                Id= 2,
                Name = "I1"
            });
            List<EsaAspect> aspects = new List<EsaAspect>();
            aspects.Add(new EsaAspect()
            {
                AspectId = 0,
            });
            aspects.Add(new EsaAspect()
            {
                AspectId = 2,
            });

            List<SecurityRequirementProject> srps = Logic.SaveReqruirementsToProject(aspects, bivs, project).ToList();

            Assert.IsTrue(srps.Count > 1);
        }
    }
}
