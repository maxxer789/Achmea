using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaProject.Models;
using AchmeaTestss.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AchmeaTestss.TestClasses
{
    [TestClass]
    public class RequirementTest
    {
        IRequirement _IReq;
        RequirementLogic Logic;

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
        public void CreateNewRequirement()
        {
            List<int> bivIds = new List<int>();
            List<int> areaIds = new List<int>();
            SecurityRequirement req = new SecurityRequirement("New Requirement", "New Description", "New Details", "AP", "AP1", "7. groep 7");
            bivIds.Add(1);
            areaIds.Add(1);

            int initialRequirementsAmount = Logic.GetAllRequirements().Count;

            Logic.CreateRequirement(req, bivIds, areaIds);

            int amountAfterCreate = Logic.GetAllRequirements().Count;

            Assert.AreNotEqual(initialRequirementsAmount, amountAfterCreate);
        }
    }
}
