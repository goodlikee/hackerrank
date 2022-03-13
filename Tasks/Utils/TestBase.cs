using System;
using System.IO;
using NUnit.Framework;

namespace Tasks.Utils
{
    public abstract class TestBase<TType>
    {
        private const string InputFileName = "Input.txt";
        private const string OutputFileName = "Output.txt";
        private const string TestCaseDirectoryName = "TestCase";

        private StreamRedirection _streamRedirection;
        private StreamRedirection _streamExpectedOutput;
        private StreamRedirection _streamOutput;

        [SetUp]
        public void Setup()
        {
            var testCasePath = Path.GetFullPath(@"..\..\..\..\")
                               + NamespaceToPath(typeof(TType).Namespace)
                               + $"\\{TestCaseDirectoryName}\\{TestContext.CurrentContext.Test.Name}";

            Environment.SetEnvironmentVariable("OUTPUT_PATH", $"{testCasePath}\\{OutputFileName}");
            _streamRedirection = ConsoleHelpers.RedirectInputFileToConsole($"{testCasePath}\\{InputFileName}");
            _streamExpectedOutput = StreamHelper.Make(File.OpenRead($"{testCasePath}\\ExpectedOutput.txt"));
        }

        [TearDown]
        public void TearDown()
        {
            _streamRedirection.Dispose();
            _streamExpectedOutput.Dispose();
            _streamOutput.Dispose();
            File.Delete(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"));
        }

        private static string NamespaceToPath(string str)
        {
            return str.Replace(".", "\\");
        }

        protected void RunTest<T>()
        {
            typeof(T).GetMethod("Main2")?.Invoke(null, new object[] {Array.Empty<string>()});
            _streamOutput = StreamHelper.Make(File.OpenRead(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH")));
            var s1 = _streamExpectedOutput.StreamReader.ReadToEnd().Trim();
            var s2 = _streamOutput.StreamReader.ReadToEnd().Trim();
            Assert.IsTrue(string.Equals(s1, s2));
        }
    }
}