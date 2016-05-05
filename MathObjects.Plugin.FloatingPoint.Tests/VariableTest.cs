using NUnit.Framework;
using System;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;

namespace MathObjects.Plugin.FloatingPoint.Tests
{
    [TestFixture]
    public class VariableTest
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

            parser.Parse("a=1;b=1", stack, scope);

            parser.Parse("x=a+b;", stack, scope);

            Assert.AreEqual(2, stack.Top.GetDouble());

            parser.Parse("a=2;x", stack, scope);

            Assert.AreEqual(3, stack.Top.GetDouble());
        }
    }
}

