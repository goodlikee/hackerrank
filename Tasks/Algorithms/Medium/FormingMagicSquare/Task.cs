﻿using NUnit.Framework;
using Tasks.Utils;
using System.IO;

namespace Tasks.Algorithms.Medium.FormingMagicSquare
{
    public class Task : TestBase<Task>
    {
        [Test]
        public void Test1()
        {
            runTest<Solution>();
        }

        [Test]
        public void Test2()
        {
            runTest<Solution>();
        }
    }
}