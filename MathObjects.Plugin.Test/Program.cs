using System;
using MathObjects.Framework.Parser;
using MathObjects.Core.Plugin;
using MathObjects.Framework;

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

            parser.Parse("a=1", stack, scope);

            parser.Parse("sum=a+b", stack, scope);

            //var canDefine = ((stack.Top as IHasOutput).Output as IHasOutput).Output as ICanBeDefined;

            var canDefine2 = (stack.Top as IHasValue).Value as ICanBeDefined;

        }
    }
}
