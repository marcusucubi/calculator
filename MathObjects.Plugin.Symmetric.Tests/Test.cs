using NUnit.Framework;
using System;
using MathObjects.Framework.Registry;
using MathObjects.Framework;

namespace MathObjects.Plugin.Symmetric.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestCase()
        {
            var reg = new FactoryRegistry();
            var plugin = new Plugin();

            plugin.Init(reg);

            var factory = reg.GetObjectFactory(FactoryRegistry.OBJECT);

            var context = new FactoryContext();
            context.InitObject = "(2, 3)";
            var trans = factory.Create(context) as IHasOutput;

            var parseValue = trans.Output;
            Assert.AreEqual("( 2, 3 )", parseValue);
        }

        [Test]
        public void TestCase2()
        {
            var reg = new FactoryRegistry();
            var plugin = new Plugin();

            plugin.Init(reg);

            var factory = reg.GetObjectFactory(FactoryRegistry.OBJECT);

            var context = new FactoryContext();
            context.InitObject = "( 1, 2, 3 )";
            var trans = factory.Create(context) as IHasOutput;

            var parseValue = trans.Output;
            Assert.AreEqual(parseValue, "( 1, 2, 3 )");
        }

        [Test]
        public void TestCase3()
        {
            var reg = new FactoryRegistry();
            var plugin = new Plugin();

            plugin.Init(reg);

            var factory = reg.GetObjectFactory(FactoryRegistry.OBJECT);

            var context = new FactoryContext();
            context.InitObject = "( 3, 2, 1 )";
            var trans = factory.Create(context) as IHasOutput;

            var parseValue = trans.Output;
            Assert.AreEqual(parseValue, "( 1, 3, 2 )");
        }
    }
}

