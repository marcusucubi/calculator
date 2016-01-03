using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Symmetric
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName
    {
        public string Name
        {
            get { return "Symmetric"; }
        }
            
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
                new Compose.Factory());
        }
    }
}

