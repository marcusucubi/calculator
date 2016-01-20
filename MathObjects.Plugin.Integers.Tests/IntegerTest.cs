using NUnit.Framework;
using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Integers.Tests
{
    [TestFixture]
    public class IntegerTest
    {
        [Test]
        public void TestObjectFactory ()
        {
            var registry = new FactoryRegistry ();
            new Plugin().Init(registry);

            var factory = registry.GetObjectFactory (FactoryRegistry.OBJECT);
            Assert.NotNull(factory);

            var i = factory.Create("1");
            Assert.NotNull (i);
        }

        [Test]
        public void TestOperationFactory ()
        {
            var registry = new FactoryRegistry ();
            new Plugin().Init(registry);

            var factory = registry.GetObjectFactory (FactoryRegistry.OBJECT);
            Assert.NotNull(factory);

            var addFactory = registry.GetBinaryOperationFactory (FactoryRegistry.ADD);
            Assert.NotNull(addFactory);

            var i1 = factory.Create("1");
            Assert.NotNull (i1);

            var add = addFactory.Create (null);
            Assert.NotNull (add);

            var result = add.Perform (i1, i1) as IHasValue;
            Assert.AreEqual (2, result.Value);
        }

        [Test]
        public void TestMultiplyOperationFactory ()
        {
            var registry = new FactoryRegistry ();
            new Plugin().Init(registry);

            var factory = registry.GetObjectFactory (FactoryRegistry.OBJECT);
            Assert.NotNull(factory);

            var multiplyFactory = registry.GetBinaryOperationFactory (FactoryRegistry.MULTIPLY);
            Assert.NotNull(multiplyFactory);

            var i1 = factory.Create("2");
            Assert.NotNull (i1);

            var multiply = multiplyFactory.Create (null);
            Assert.NotNull (multiply);

            var result = multiply.Perform (i1, i1) as IHasValue;
            Assert.AreEqual (4, result.Value);
        }
    }
}

