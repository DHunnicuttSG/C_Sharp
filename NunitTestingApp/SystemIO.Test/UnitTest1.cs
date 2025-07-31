using Microsoft.VisualStudio.TestPlatform.TestHost;
using NunitTestingApp;
using NUnit.Framework;
namespace SystemIO.Test
{
    [TestFixture]
    public class Tests
    {
        
        [Test]
        public void TestAddNumbers()
        {
            var p1 = new NunitTestingApp.Program();

            int x = 5;
            int y = 6;
            int result = AddTwoNumbers(x,y);

            Assert.AreEqual(11, AddTwoNums(x, y));
        }
    }
}