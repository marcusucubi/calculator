using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.Rational
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName, IHasParser
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
        }

        public void Init(FactoryRegistry registry)
        {
            this.parser = new Parser(registry);

            registry.RegisterObjectFactory(
                FactoryRegistry.OBJECT, 
                new MathObject.Factory());
            
            registry.RegisterOperationFactory2(
                FactoryRegistry.ADD, 
                new Add.Factory());
            
            registry.RegisterOperationFactory2(
                FactoryRegistry.MULTIPLY, 
                new Multiply.Factory());

            registry.RegisterOperationFactory2(
                FactoryRegistry.INVERSE, 
                new Inverse.Factory());
        }
    }
}

