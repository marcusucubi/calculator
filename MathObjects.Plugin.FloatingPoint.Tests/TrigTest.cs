using NUnit.Framework;
using System;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;

namespace MathObjects.Plugin.FloatingPoint.Tests
{
    [TestFixture]
    public class TrigTest
    {
        IParser parser;

        [SetUp]
        public void Setup()
        {
            var plugin = new MathObjects.Plugin.FloatingPoint.Plugin();

            var loader = new PluginLoader();

            plugin.Startup(loader);

            parser = (plugin as IHasParser).Parser;
        }

        [Test]
        public void TestCase5()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("pi()", stack, scope);

            Assert.AreEqual(Math.PI, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase6()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("cos(radians(pi()))", stack, scope);

            Assert.AreEqual(-1, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase7()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("cos(degrees(180))", stack, scope);

            Assert.AreEqual(-1, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase8()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("degrees(acos(cos(degrees(60))))", stack, scope);

            Assert.AreEqual(60, stack.Top.GetDouble());
        }
    }
}

