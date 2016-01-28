using NUnit.Framework;
using System;

namespace MathObjects.Framework.Parser.Tests
{
    [TestFixture]
    public class MathObjectStackTest
    {
        [Test]
        public void TestCase()
        {
            var stack = new MathObjectStack();

            stack.Push(new TestObject("hello"));

            var result = stack.Pop();

            Assert.AreEqual("hello", result.ToString());
        }

        [Test]
        public void TestCase2()
        {
            var stack = new MathObjectStack();

            stack.Push(new TestObject("there"));

            stack.Push(new TestObject("hello"));

            stack.Push(new TestBinaryOperation());

            var result = stack.Pop() as IHasOutput;

            Assert.AreEqual("hello there", result.Output.ToString());
        }

        [Test]
        public void TestCase3()
        {
            var stack = new MathObjectStack();

            stack.Push(new TestObject("hello"));

            stack.Push(new TestUniraryOperation());

            var result = stack.Pop() as IHasOutput;

            Assert.AreEqual("(hello)", result.Output.ToString());
        }

        [Test]
        public void TestCase4()
        {
            var stack = new MathObjectStack();

            bool changed = false;

            stack.StackChanged += (sender, e) => { changed=true; };

            stack.Push(new TestObject("hello"));

            Assert.IsTrue(changed);
        }

        [Test]
        public void TestCase5()
        {
            var stack = new MathObjectStack();

            stack.Push(new TestObject("hello"));

            stack.Clear();

            Assert.AreEqual(0, stack.ObjectStack.Count);
        }
    }
}

