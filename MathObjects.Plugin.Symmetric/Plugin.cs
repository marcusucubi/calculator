using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Plugin.Symmetric.Parser;

namespace MathObjects.Plugin.Symmetric
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName, IHasParser
    {
        IParser parser;

        public IParser Parser
        {
            get { return parser; }
        }

        public string Name
        {
            get { return "Symmetric"; }
        }
            
        public void Startup(IPluginLoader loader)
        {
        }

        public void Init(FactoryRegistry registry)
        {
            this.parser = new Parser2(registry);

            registry.RegisterObjectFactory(
                FactoryRegistry.OBJECT, 
                new MathObject.Factory());
            
            registry.RegisterBinaryOperationFactory(
                FactoryRegistry.ADD, 
                new Compose.Factory());
            
            registry.RegisterOperationFactory2(
                "Inverse", new Inverse.Factory());
        }
    }
}

