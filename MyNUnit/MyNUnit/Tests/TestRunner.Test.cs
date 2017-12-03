using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace MyNUnit.Tests
{
    [TestFixture]
    public class TestRunnerTest
    {
        private static readonly string Homedir = TestContext.CurrentContext.TestDirectory;
        private const string NavigateInDir = "../../Tests/TestFiles/";

        [Test]
        public void TestNoBefore()
        {
            const string localDir = "./NoBeforeAfter/";
            var result = RunTest(localDir);
            var enumerable =  RunTest(localDir) as IList<string> ?? result.ToList();
            Assert.IsTrue(enumerable.Where(x => x.Contains("Test successfully finished")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Ignoring test")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Did catch expected")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Run failed")).ToList().Count == 3);
        }

        [Test]
        public void TestMethodBefore()
        {
            const string localDir = "./MethodBeforeAfter/";
            var result = RunTest(localDir);
            var enumerable =  RunTest(localDir) as IList<string> ?? result.ToList();
            Assert.IsTrue(enumerable.Where(x => x.Contains("Test successfully finished")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Ignoring test")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Did catch expected")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Run failed")).ToList().Count == 3);
        }

        [Test]
        public void TestClassBefore()
        {
            const string localDir = "./ClassBeforeAfter/";
            var result = RunTest(localDir);
            var enumerable =  RunTest(localDir) as IList<string> ?? result.ToList();
            Assert.IsTrue(enumerable.Where(x => x.Contains("Test successfully finished")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Ignoring test")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Did catch expected")).ToList().Count == 3);
            Assert.IsTrue(enumerable.Where(x => x.Contains("Run failed")).ToList().Count == 3);
        }

        private static IEnumerable<string> RunTest(string localDir) => 
            new TestRunner(Path.Combine(Homedir, NavigateInDir, localDir)).RunTests();
    }
}