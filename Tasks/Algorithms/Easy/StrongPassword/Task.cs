using NUnit.Framework;
using Tasks.Utils;
using System.IO;

namespace Tasks.Algorithms.Easy.StrongPassword
{
    public class Task : TestBase<Task>
    {
        [Test]
        public void Test1()
        {
            RunTest<Solution>();
        }
    }
}