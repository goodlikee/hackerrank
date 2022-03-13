using System;
using System.IO;
using NUnit.Framework;

namespace Tasks.Utils
{
    public abstract class TestBase<TType>
    {
        private const string InputFileName = "Input.txt";
        private const string OutputFileName = "Output.txt";
        private StreamRedirection _streamRedirection;
        protected StreamRedirection _streamExpectedOutput;
        protected StreamRedirection _streamOutput;


        protected string testCaseDirecotyName = "TestCase";

        [SetUp]
        public void Setup()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var type = typeof(TType);
            string solutionFullPath = System.IO.Path.GetFullPath(@"..\..\..\..\");
            string testCasePath = solutionFullPath + NamespaceToPath(type.Namespace) +
                                  $"\\{testCaseDirecotyName}\\{testName}";

            @System.Environment.SetEnvironmentVariable("OUTPUT_PATH", $"{testCasePath}\\{OutputFileName}");
            _streamRedirection = ConsoleHelpers.RedirectInputFileToConsole($"{testCasePath}\\{InputFileName}");
            _streamExpectedOutput =
                StreamHelper.Make(File.OpenRead($"{testCasePath}\\ExpectedOutput.txt"));
        }

        [TearDown]
        public void TearDown()
        {
            _streamRedirection.Dispose();
            _streamExpectedOutput.Dispose();
            _streamOutput.Dispose();
            File.Delete(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"));
        }

        private string NamespaceToPath(string str)
        {
            return str.Replace(".", "\\");
        }

        protected void runTest<T>()
        {
            typeof(T).GetMethod("Main2")?.Invoke(null, new object[] {Array.Empty<string>()});
            _streamOutput = StreamHelper.Make(File.OpenRead(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH")));
            var s1 = _streamExpectedOutput.StreamReader.ReadToEnd().Trim();
            var s2 = _streamOutput.StreamReader.ReadToEnd().Trim();
            Assert.IsTrue(string.Equals(s1, s2));
        }
    }
}