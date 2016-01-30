using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Plugin.Integers.Func;

namespace MathObjects.Plugin.Integers
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName, IHasParser
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
        }

        public void Init(FactoryRegistry registry)
        {
            this.parser = new Parser(registry);

            registry.RegisterObjectFactory(
                FactoryRegistry.OBJECT, 
                new MathObject.Factory());

            registry.RegisterBinaryOperationFactory(
                FactoryRegistry.ADD, 
                new Add.Factory());

            registry.RegisterBinaryOperationFactory(
                FactoryRegistry.MULTIPLY, 
                new Multiplication.Factory());
            
            registry.RegisterBinaryOperationFactory(
                "gcd", new Gcd.Factory());
            
            registry.RegisterFunctionFactory(
                "top", new FunctionFactory(typeof(TopFunction)));
        }
    }
}

