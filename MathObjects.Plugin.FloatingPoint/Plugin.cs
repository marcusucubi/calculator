using System;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Plugin.FloatingPoint.MathFunc;
using MathObjects.Plugin.FloatingPoint.Func;
using System.Collections.Generic;
using MathObjects.Framework.Vocabulary;
using System.Collections.ObjectModel;

namespace MathObjects.Plugin.FloatingPoint
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName, IHasParser, IHasVocabulary
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
            
            registry.RegisterOperationFactory2(
                FactoryRegistry.ADD, 
                new Add.Factory());
            
            registry.RegisterOperationFactory2(
                FactoryRegistry.SUBTRACT, 
                new Subtract.Factory());

            registry.RegisterOperationFactory2(
                FactoryRegistry.MULTIPLY, 
                new Multiply.Factory());
            
            registry.RegisterOperationFactory2(
                FactoryRegistry.DIVIDE, 
                new Divide.Factory());

            registry.RegisterFunctionFactory(
                "pi", new ConstantFunction.Factory(Math.PI));

            registry.RegisterFunctionFactory(
                "top", new FunctionFactory(typeof(TopFunction)));

            registry.RegisterFunctionFactory(
                "degrees", new FunctionFactory(typeof(DegreesFunction)));
            
            registry.RegisterFunctionFactory(
                "radians", new FunctionFactory(typeof(RadiansFunction)));

            MathFuncObject.Init(registry);
        }

        public ReadOnlyCollection<WordGroup> WordGroups
        {
            get
            {
                var vocab = new List<WordGroup>();

                {
                    var words = new WordGroup("Standard", new string[] 
                        { 
                            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0",
                            "+", "*", "-", "/", "^", "(", ")" 
                        }
                    );
                    vocab.Add(words);
                }
                {
                    var words = new WordGroup("Triganometry", new string[] 
                        { 
                            "sin()", "cos()", "tan()", "asin()", "acos()", "atan()",
                            "pi()", "degrees()", "radians()"
                        }
                    );
                    vocab.Add(words);
                }

                return vocab.AsReadOnly();
            }
        }

    }
}

