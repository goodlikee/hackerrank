using NUnit.Framework;
using Tasks.Utils;
using System.IO;

namespace Tasks.Algorithms.Easy.DesignerPDFViewer
{
    public class Task : TestBase<Task>
    {
        [Test]
        public void Test1()
        {
            runOneTest();
        }

        [Test]
        public void Test2()
        {
            runOneTest();
        }

        private void runOneTest()
        {
            Solution.Main2(null);
            _streamOutput = StreamHelper.Make(File.OpenRead(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH")));

            var s1 = _streamExpectedOutput.StreamReader.ReadLine();
            var s2 = _streamOutput.StreamReader.ReadLine();
            Assert.IsTrue(string.Equals(s1, s2));
        }
    }
}