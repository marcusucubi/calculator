using NUnit.Framework;
using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Rational.Tests
{
    [TestFixture()]
    public class Test
    {
        [Test]
        public void TestOperationFactory ()
        {
            var parser = new Parser();
            var stack = new MathObjectStack();

            parser.Parse("1+1", stack, null);
            var result = stack.Pop();

            Assert.AreEqual (2, result.GetTuple().Item1);
        }

        [Test]
        public void TestMultiplyOperationFactory ()
        {
            var parser = new Parser();
            var stack = new MathObjectStack();

            parser.Parse("2 * 2", stack, null);
            var result = stack.Pop();

            Assert.AreEqual (4, result.GetTuple().Item1);
        }
    }
}

