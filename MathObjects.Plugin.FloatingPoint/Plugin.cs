using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.FloatingPoint
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName
    {
        public string Name
        {
            get { return "FloatingPoint"; }
        }
            
        public void Startup(IPluginLoader loader)
        {
        }

        public void Init(FactoryRegistry registry)
        {
            registry.Parser = new Parser();

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
        }
    }
}

