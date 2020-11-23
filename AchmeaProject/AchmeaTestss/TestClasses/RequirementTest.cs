using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaTestss.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AchmeaTestss.TestClasses
{
    [TestClass]
    class RequirementTest
    {
        IRequirement _IReq;
        RequirementLogic Logic;

        public RequirementTest()
        {
            _IReq = new MockRequirementDAL();
            Logic = new RequirementLogic(_IReq);
        }
    }
}
