using NUnit.Framework;
using System;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;

namespace MathObjects.Plugin.FloatingPoint.Tests
{
    [TestFixture]
    public class TopTest
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

            parser.Parse("1;top()", stack, scope);

            Assert.AreEqual(1, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase1()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("1;t=top();2;t", stack, scope);

            Assert.AreEqual(2, stack.Top.GetDouble());
        }
    }
}

