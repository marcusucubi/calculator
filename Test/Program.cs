using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Tree;
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

            parser.Parse("1+2", stack);

            var top = stack.Top;
        }
    }
}
