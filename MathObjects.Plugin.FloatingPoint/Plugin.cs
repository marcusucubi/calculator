using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Vocabulary;
using MathObjects.Plugin.FloatingPoint.MathFunc;
using MathObjects.Plugin.FloatingPoint.Func;

namespace MathObjects.Plugin.FloatingPoint
{
    [Plugin]
    public class Plugin : IPlugin, IHasName, IHasParser, IHasVocabulary
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
            var registry = new FunctionRegistry();

            registry.Put(
                "pi", new ConstantOperationFactory.Factory(Math.PI));

            registry.Put(
                "e", new ConstantOperationFactory.Factory(Math.E));

            registry.Put(
                "top", new FunctionFactory(typeof(TopOperationFactory)));

            registry.Put(
                "degrees", new FunctionFactory(typeof(DegreesOperationFactory)));
            
            registry.Put(
                "radians", new FunctionFactory(typeof(RadiansOperationFactory)));
        
            registry.Put(
                "ln", new MathOperationFactory.Factory(((i) => Math.Log(i)), "ln"));

            registry.Put(
                "log", new MathOperationFactory.Factory(((i) => Math.Log10(i)), "log"));
            
            registry.Put(
                "exp", new MathOperationFactory.Factory(((i) => Math.Exp(i)), "exp"));

            registry.Put(
                "sqrt", new MathOperationFactory.Factory(((i) => Math.Sqrt(i)), "sqrt"));

            registry.Put(
                "square", new MathOperationFactory.Factory(((i) => ( i * i )), "square"));

            registry.Put(
                "inverse", new MathOperationFactory.Factory(((i) => ( 1/i )), "inverse"));

            registry.Put(
                "sin", new AngleOperationFactory.Factory(((i) => Math.Sin(i)), "sin"));
            
            registry.Put(
                "cos", new AngleOperationFactory.Factory(((i) => Math.Cos(i)), "cos"));
            
            registry.Put(
                "tan", new AngleOperationFactory.Factory(((i) => Math.Tan(i)), "tan"));
            
            registry.Put(
                "asin", new InverseAngleOperationFactory.Factory(((i) => Math.Asin(i)), "asin"));

            registry.Put(
                "acos", new InverseAngleOperationFactory.Factory(((i) => Math.Acos(i)), "acos"));

            registry.Put(
                "atan", new InverseAngleOperationFactory.Factory(((i) => Math.Atan(i)), "atan"));

            parser = new Parser(registry);
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
                            "+", "*", "-", "/", "^", "(", ")", "=", ";",
                            "top()", "sqrt()", "square()", "inverse()"
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
                {
                    var words = new WordGroup("Log", new string[] 
                        { 
                            "ln()", "log()", "exp()", "e()"
                        }
                    );
                    vocab.Add(words);
                }
                {
                    var words = new WordGroup("Leters", new string[] 
                        { 
                            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                            "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
                            "u", "v", "w", "x", "y", "z"
                        }
                    );
                    vocab.Add(words);
                }

                return vocab.AsReadOnly();
            }
        }

    }
}

