using NUnit.Framework;
using System;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;

namespace MathObjects.Plugin.FloatingPoint.Tests
{
    [TestFixture()]
    public class ConstantTest
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
        public void TestCase()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("e()", stack, scope);

            Assert.AreEqual(Math.E, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase1()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("pi()", stack, scope);

            Assert.AreEqual(Math.PI, stack.Top.GetDouble());
        }
    }
}

