using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Plugin.FloatingPoint.MathFunc;
using MathObjects.Plugin.FloatingPoint.Func;
using MathObjects.Framework.Vocabulary;

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
                "top", new FunctionFactory(typeof(TopFunction)));

            registry.Put(
                "degrees", new FunctionFactory(typeof(DegreesFunction)));
            
            registry.Put(
                "radians", new FunctionFactory(typeof(RadiansFunction)));
        
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

