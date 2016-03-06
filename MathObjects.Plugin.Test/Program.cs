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

            parser.Parse("1+2", stack);
        }
    }
}
