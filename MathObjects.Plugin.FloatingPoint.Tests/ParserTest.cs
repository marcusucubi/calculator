using NUnit.Framework;
using System;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

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
    }
}

