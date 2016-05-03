using NUnit.Framework;
using System;

namespace MathObjects.Core.DecoratableObject.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestCase()
        {
            var obj = new TestObject();

            var s = obj.GetClassDecoration<string>("name");

            Assert.AreEqual("TestName", s);
        }

        [Test]
        public void TestCase2()
        {
            var obj = new TestObject();
            var obj2 = new TestObject();

            obj2.CopyDecorations(obj);

            var s = obj2.GetClassDecoration<string>("name");

            Assert.AreEqual("TestName", s);
        }

        [Test]
        public void TestCase3()
        {
            var obj = new TestObject();
            var obj2 = new TestObject();

            obj.SetObjectDecoration("test", "test");

            obj2.CopyDecorations(obj);

            var s = obj2.GetObjectDecoration<string>("test");

            Assert.AreEqual("test", s);
        }
    }
}

