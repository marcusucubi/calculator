using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;

namespace MathObjects.Plugin.Rational
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit
    {
        public void Startup(IPluginLoader loader)
        {
        }

        public void Init(FactoryRegistry registry)
        {
            registry.RegisterObjectFactory(
                FactoryRegistry.OBJECT, 
                new MathObject.Factory());
            
            registry.RegisterOperationFactory(
                FactoryRegistry.ADD, 
                new Add.Factory());
            
            registry.RegisterOperationFactory(
                FactoryRegistry.MULTIPLY, 
                new Multiply.Factory());

            registry.RegisterOperationFactory2(
                FactoryRegistry.INVERSE, 
                new Inverse.Factory());
        }
    }
}

