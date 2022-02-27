using System.IO;
using NUnit.Framework;

namespace Tasks.Utils
{
    public abstract class TestBase<TType>
    {
        private const string OutputFileName = "Output.txt";
        private StreamRedirection _streamRedirection;
        protected StreamRedirection _streamExpectedOutput;
        protected StreamRedirection _streamOutput;

        [SetUp]
        public void Setup()
        {
            var type = typeof(TType);
            @System.Environment.SetEnvironmentVariable("OUTPUT_PATH", $"{type.Namespace}.{OutputFileName}");
            _streamRedirection = ConsoleHelpers.RedirectInputFileToConsole(type);
            _streamExpectedOutput =
                StreamHelper.Make(type.Assembly.GetManifestResourceStream($"{type.Namespace}.ExpectedOutput.txt"));
        }

        [TearDown]
        public void TearDown()
        {
            _streamRedirection.Dispose();
            _streamExpectedOutput.Dispose();
            _streamOutput.Dispose();
            File.Delete(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"));
        }
    }
}