using NUnit.Framework;
using System;
using System.Diagnostics;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;

namespace MathObjects.Plugin.FloatingPoint.Tests
{
    [TestFixture]
    public class ParserTest
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

            parser.Parse("1+2", stack, scope);

            Assert.AreEqual(3, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase2()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("1*2", stack, scope);

            Assert.AreEqual(2, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase3()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("(1*2)+(3*4)", stack, scope);

            Assert.AreEqual(14, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase4()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("1*2+3*4", stack, scope);

            Assert.AreEqual(14, stack.Top.GetDouble());
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

        [Test]
        public void TestCase9()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("a=1;b=2;c=-3;delta=b^2-4*a*c", stack, scope);

            Assert.AreEqual(16, stack.Top.GetDouble());
        }
    }
}

