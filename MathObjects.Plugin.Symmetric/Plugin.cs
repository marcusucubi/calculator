using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Vocabulary;
using MathObjects.Plugin.Symmetric.Parser;

namespace MathObjects.Plugin.Symmetric
{
    [Plugin]
    public class Plugin : 
        IPlugin, IHasName, IHasParser, IHasVocabulary
    {
        IParser parser;

        public Plugin()
        {
            var registry = new FunctionRegistry();

            parser = new Parser2(registry);
        }

        public IParser Parser
        {
            get { return parser; }
        }

        public string Name
        {
            get { return "Symmetric"; }
        }

        public ReadOnlyCollection<WordGroup> WordGroups
        {
            get
            {
                var vocab = new List<WordGroup>();

                {
                    var words = new WordGroup("S3", new string[] 
                    { "( )", "(1, 2)", "(1, 3)", "(2, 3)", "(1, 2, 3)", "(2, 3, 1)" }
                            );
                    vocab.Add(words);
                }
                {
                    var words = new WordGroup("S4", new string[] 
                        { "( )", "(1, 2)", "(1, 3)", "(2, 3)", "(1, 2, 3)", "(2, 3, 1)",
                          "( )", "(1, 4)", "(2, 4)", "(3, 4)", "(1, 2, 3, 4)", "(2, 3, 4, 1)" }
                    );
                    vocab.Add(words);
                }

                return vocab.AsReadOnly();
            }
        }

        public void Startup(IPluginLoader loader)
        {
        }
    }
}

