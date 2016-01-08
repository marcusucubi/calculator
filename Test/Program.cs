using System;
using MathObjects.Framework.Registry;
using MathObjects.Plugin.Symmetric;
using MathObjects.Framework;
using System.Diagnostics;

namespace Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var reg = new FactoryRegistry();
            var plugin = new Plugin();

            plugin.Init(reg);

            var factory = reg.GetObjectFactory(FactoryRegistry.OBJECT);

            var trans = factory.Create("(3 2 1)") as IHasParseValue;

            var parseValue = trans.ParseValue;

            //Debug.Assert("( 1 3 2 )" == parseValue);

            Console.WriteLine("Success!");

//            Console.In.Read();
        }
    }
}
