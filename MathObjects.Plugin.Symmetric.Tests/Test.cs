using NUnit.Framework;
using System;
using MathObjects.Framework.Registry;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric.Tests
{
    [TestFixture]
    public class Test
    {
        IParser parser;

        [SetUp]
        public void Setup()
        {
            var plugin = new Plugin();

            parser = (plugin as IHasParser).Parser;
        }

        [Test]
        public void TestCase()
        {
            var stack = new MathObjectStack();

            parser.Parse("(1,2,3,4)", stack, null);

            var cycle = CycleList.Create(new int[] {1,2,3,4});
            Assert.AreEqual(cycle, stack.Top.GetCycleList());
        }

        [Test]
        public void TestCase2()
        {
            var stack = new MathObjectStack();

            parser.Parse("(1,2,3)(1,2,3)(1,2,3)", stack, null);

            var cycle = CycleList.Create(new int[] {});
            Assert.AreEqual(cycle, stack.Top.GetCycleList());
        }

        [Test]
        public void TestCase3()
        {
            var stack = new MathObjectStack();

            parser.Parse("(1,2)(1,2)", stack, null);

            var cycle = CycleList.Create(new int[] {});
            Assert.AreEqual(cycle, stack.Top.GetCycleList());
        }
    }
}

