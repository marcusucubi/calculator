using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;

namespace MathObjects.Plugin.FloatingPoint
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName, IHasParser
    {
        IParser parser;

        public string Name
        {
            get { return "FloatingPoint"; }
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
            
            registry.RegisterOperationFactory(
                FactoryRegistry.ADD, 
                new Add.Factory());
            
            registry.RegisterOperationFactory(
                FactoryRegistry.SUBTRACT, 
                new Subtract.Factory());

            registry.RegisterOperationFactory(
                FactoryRegistry.MULTIPLY, 
                new Multiply.Factory());
            
            registry.RegisterOperationFactory(
                FactoryRegistry.DIVIDE, 
                new Divide.Factory());

            registry.RegisterFunctionFactory(
                "pi", new ConstantObjectFactory(Math.PI));
            
            registry.RegisterFunctionFactory(
                "top", new ConstantObjectFactory(Math.PI));
        }
    }
}

