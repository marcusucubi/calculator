using NUnit.Framework;
using System;

namespace MathObjects.Core.Matrix.Permutation.Tests
{
    [TestFixture()]
    public class Test
    {
        [Test]
        public void TestCase()
        {
            var cycle = CycleList.Create("(1 2)");

            int n1 = cycle.CycleSet[0];
            int n2 = cycle.CycleSet[1];

            Assert.AreEqual(1, n1);
            Assert.AreEqual(2, n2);
        }

        [Test]
        public void TestCase2()
        {
            var cycle = CycleList.Create("(1 2 3)");

            int n1 = cycle.CycleSet[0];
            int n2 = cycle.CycleSet[1];
            int n3 = cycle.CycleSet[2];

            Assert.AreEqual(1, n1);
            Assert.AreEqual(2, n2);
            Assert.AreEqual(3, n3);
        }

        [Test]
        public void TestCase3()
        {
            var cycle = CycleList.Create("(1 2 3)");

            int n1 = cycle.CycleSet[0];
            int n2 = cycle.CycleSet[1];
            int n3 = cycle.CycleSet[2];

            Assert.AreEqual(1, n1);
            Assert.AreEqual(2, n2);
            Assert.AreEqual(3, n3);
        }
    }
}

