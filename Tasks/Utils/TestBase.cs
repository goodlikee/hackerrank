using NUnit.Framework;

namespace Tasks.Utils
{
    public abstract class TestBase<TType>
    {
        private StreamRedirection _streamRedirection;

        [SetUp]
        public void Setup()
        {
            _streamRedirection = ConsoleHelpers.RedirectInputFileToConsole(typeof(TType));
        }

        [TearDown]
        public void TearDown()
        {
            _streamRedirection.Dispose();
        }
    }
}