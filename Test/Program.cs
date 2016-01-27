using System;
using System.IO;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Plugin.FloatingPoint;

namespace Test
{
    class MainClass
    {
        static FactoryRegistry reg = new FactoryRegistry();

        static Plugin plugin = new Plugin();

        static IParser parser;

        public static void Main(string[] args)
        {
            plugin.Init(reg);
            
            parser = (plugin as IHasParser).Parser;
        
            var stack = new MathObjectStack();

            parser.Parse("(1*2)+(3*4)", stack);

            Console.WriteLine(stack.Print());

            var top = stack.Top;
        }
    }
}
