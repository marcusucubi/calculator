using NUnit.Framework;
using System;

namespace MathObjects.Framework.Tests
{
    [TestFixture ()]
    public class FactoryRegistryTest
    {
        [Test ()]
        public void TestObjectFactory ()
        {
            var factory = new TestObjectFactory ();
            var registry = new FactoryRegistry ();
            registry.RegisterObjectFactory ("test", factory);

            var test = registry.GetObjectFactory ("test");

            Assert.AreSame (factory, test);
        }

        [Test ()]
        public void TestOperationFactory ()
        {
            var factory = new TestOperationFactory ();
            var registry = new FactoryRegistry ();
            registry.RegisterOperationFactory ("test", factory);

            var test = registry.GetOperationFactory ("test");

            Assert.AreSame (factory, test);
        }
    }
}

