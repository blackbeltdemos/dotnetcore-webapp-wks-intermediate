namespace MyFirstProject.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //test
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [Ignore]
        public void TestMethod4()
        {
            Assert.IsTrue(true);
        }
    }
}
