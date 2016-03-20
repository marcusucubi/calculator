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
                "pi", new ConstantFunction.Factory(Math.PI));

            registry.Put(
                "ee", new ConstantFunction.Factory(Math.E));

            registry.Put(
                "top", new FunctionFactory(typeof(TopFunction)));

            registry.Put(
                "degrees", new FunctionFactory(typeof(DegreesFunction)));
            
            registry.Put(
                "radians", new FunctionFactory(typeof(RadiansFunction)));
        
            registry.Put(
                "ln", new MathFunction.Factory(((i) => Math.Log(i)), "ln"));

            registry.Put(
                "log", new MathFunction.Factory(((i) => Math.Log10(i)), "log"));
            
            registry.Put(
                "exp", new MathFunction.Factory(((i) => Math.Exp(i)), "exp"));

            registry.Put(
                "sqrt", new MathFunction.Factory(((i) => Math.Sqrt(i)), "sqrt"));

            registry.Put(
                "square", new MathFunction.Factory(((i) => ( i * i )), "square"));

            registry.Put(
                "inverse", new MathFunction.Factory(((i) => ( 1/i )), "inverse"));

            registry.Put(
                "sin", new AngleFunction.Factory(((i) => Math.Sin(i)), "sin"));
            
            registry.Put(
                "cos", new AngleFunction.Factory(((i) => Math.Cos(i)), "cos"));
            
            registry.Put(
                "tan", new AngleFunction.Factory(((i) => Math.Tan(i)), "tan"));
            
            registry.Put(
                "asin", new InverseAngleFunction.Factory(((i) => Math.Asin(i)), "asin"));

            registry.Put(
                "acos", new InverseAngleFunction.Factory(((i) => Math.Acos(i)), "acos"));

            registry.Put(
                "atan", new InverseAngleFunction.Factory(((i) => Math.Atan(i)), "atan"));

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

