using System;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;

namespace MathObjects.Plugin.Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var plugin = new MathObjects.Plugin.FloatingPoint.Plugin();

            var loader = new PluginLoader();

            plugin.Startup(loader);

            var parser = (plugin as IHasParser).Parser;

            var stack = new MathObjectStack();

            var scope = new MathScope();

            parser.Parse("x <-2;", stack, scope);

            parser.Parse("x", stack, scope);

            var top = stack.Top;

            

        }
    }
}
