using NUnit.Framework;
using System;
using System.Diagnostics;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;
using MathObjects.Framework;

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

        [Test]
        public void TestCase10()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("a=1;b=2;c=-3;delta=b^2-4*a*c", stack, scope);

            parser.Parse("q1=((-b+sqrt(delta))/(2*a))", stack, scope);

            Assert.AreEqual(1, stack.Top.GetDouble());

            parser.Parse("q2=((-b-sqrt(delta))/(2*a))", stack, scope);

            Assert.AreEqual(-3, stack.Top.GetDouble());
        }

        [Test]
        public void TestCase11()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("a", stack, scope);

            var top = stack.Pop();

            var hasOutput = top as IHasOutput;

            var canDefine = hasOutput.Output as ICanBeDefined;

            Assert.IsFalse(canDefine.IsDefinded);
        }

        [Test]
        public void TestCase12()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("a=1", stack, scope);

            parser.Parse("sum=a+b", stack, scope);

            var canDefine = (stack.Top as IHasValue).Value as ICanBeDefined;

            Assert.IsFalse(canDefine.IsDefinded);
        }

        [Test]
        public void TestCase13()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("a=1", stack, scope);

            parser.Parse("sum=a-b", stack, scope);

            var canDefine = (stack.Top as IHasValue).Value as ICanBeDefined;

            Assert.IsFalse(canDefine.IsDefinded);
        }

        [Test]
        public void TestCase14()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("a=1", stack, scope);

            parser.Parse("sum=a/b", stack, scope);

            var canDefine = (stack.Top as IHasValue).Value as ICanBeDefined;

            Assert.IsFalse(canDefine.IsDefinded);
        }

        [Test]
        public void TestCase15()
        {
            var stack = new MathObjectStack();
            var scope = new MathScope();

            parser.Parse("a=1", stack, scope);

            parser.Parse("sum=a/b", stack, scope);

            var canDefine = (stack.Top as IHasValue).Value as ICanBeDefined;

            Assert.IsFalse(canDefine.IsDefinded);
        }
    }
}

