using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Rational
{
    [Plugin]
    public class Plugin : IPlugin, IHasName, IHasParser
    {
        IParser parser;

        public string Name
        {
            get { return "Rational"; }
        }
            
        public IParser Parser 
        { 
            get { return parser; }
        }

        public void Startup(IPluginLoader loader)
        {
            parser = new Parser();
        }
    }
}

