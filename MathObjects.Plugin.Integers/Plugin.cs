using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Plugin.Integers.Func;

namespace MathObjects.Plugin.Integers
{
    [Plugin]
    public class Plugin : IPlugin, IHasName, IHasParser
    {
        IParser parser;

        public string Name
        {
            get { return "Integers"; }
        }

        public IParser Parser
        {
            get { return parser; }
        }

        public void Startup(IPluginLoader loader)
        {
            var registry = new FunctionRegistry();

            parser = new Parser(registry);
        }
    }
}

