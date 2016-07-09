using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Vocabulary;

namespace MathObjects.Plugin.FloatingPoint
{
    [Plugin]
    public class Plugin : IPlugin, IHasName, IHasParser, IHasVocabulary
    {
        IParser parser;

        public string Name
        {
            get { return "FloatingPoint2"; }
        }

        public IParser Parser
        {
            get { return parser; }
        }
            
        public void Startup(IPluginLoader loader)
        {
            var registry = new MathObjects.Plugin.FloatingPoint2.FunctionRegistry();

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
                            "random()", "sqrt()", "square()", "inverse()"
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

