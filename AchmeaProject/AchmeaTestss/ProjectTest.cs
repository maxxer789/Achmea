using Achmea.Core.Interface;
using Achmea.Core.Logic;
using AchmeaTestss.MockServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AchmeaTestss
{
    [TestClass]
    public class ProjectTest
    {
        IProject Interface = new MockProjectDAL();
        private readonly ProjectLogic _ProjectLogic;

        public ProjectTest()
        {
            _ProjectLogic = new ProjectLogic(Interface);
        }

        //test
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
