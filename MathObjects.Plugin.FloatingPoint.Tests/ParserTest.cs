using NUnit.Framework;
using System;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using System.Diagnostics;

namespace MathObjects.Plugin.FloatingPoint.Tests
{
    [TestFixture()]
    public class ParserTest
    {
        FactoryRegistry reg = new FactoryRegistry();

        Plugin plugin = new Plugin();

        IParser parser;

        [SetUp]
        public void Setup()
        {
            plugin.Init(reg);

            parser = (plugin as IHasParser).Parser;
        }

        [Test]
        public void TestCase()
        {
            var stack = new MathObjectStack();

            parser.Parse("1+2", stack);

            Assert.AreEqual(3, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase2()
        {
            var stack = new MathObjectStack();

            parser.Parse("1*2", stack);

            Assert.AreEqual(2, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase3()
        {
            var stack = new MathObjectStack();

            parser.Parse("(1*2)+(3*4)", stack);

            Assert.AreEqual(14, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase4()
        {
            var stack = new MathObjectStack();

            parser.Parse("1*2+3*4", stack);

            Assert.AreEqual(14, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase5()
        {
            var stack = new MathObjectStack();

            parser.Parse("pi()", stack);

            Assert.AreEqual(Math.PI, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase6()
        {
            var stack = new MathObjectStack();

            parser.Parse("cos(radians(pi()))", stack);

            Assert.AreEqual(-1, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase7()
        {
            var stack = new MathObjectStack();

            parser.Parse("cos(degrees(180))", stack);

            Assert.AreEqual(-1, stack.Top.GetDouble());
        }
    }
}

