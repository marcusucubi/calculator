using NUnit.Framework;
using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Integers.Tests
{
    [TestFixture]
    public class IntegerTest
    {
        [Test]
        public void TestOperationFactory ()
        {
            var parser = new Parser();
            var stack = new MathObjectStack();

            parser.Parse("1+1", stack);
            var result = stack.Pop();

            Assert.AreEqual (2, result.GetInteger());
        }

        [Test]
        public void TestMultiplyOperationFactory ()
        {
            var parser = new Parser();
            var stack = new MathObjectStack();

            parser.Parse("2*2", stack);
            var result = stack.Pop();

            Assert.AreEqual (4, result.GetInteger());
        }
    }
}

