using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AchmeaTestss
{
    [TestClass]
    public class UnitTest1
    {
        //test
        [TestMethod]
        public void TestMethod1()
        {
            int hello = 1;

            Assert.AreEqual(hello, 2);
        }

        public void TestMethod2()
        {
            int hello = 1;

            Assert.AreEqual(hello, 2);
        }
    }
}
