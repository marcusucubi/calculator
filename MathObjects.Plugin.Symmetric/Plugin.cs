﻿using System;
using System.Linq;
using MathObjects.Core.Plugin;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Vocabulary;
using MathObjects.Plugin.Symmetric.Parser;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MathObjects.Plugin.Symmetric
{
    [Plugin]
    public class Plugin : IPlugin, IHasInit, IHasName, IHasParser, IHasVocabulary
    {
        IParser parser;

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

        public void Init(FactoryRegistry registry)
        {
            this.parser = new Parser2(registry);

            registry.RegisterObjectFactory(
                FactoryRegistry.OBJECT, 
                new MathObject.Factory());
            
            registry.RegisterOperationFactory2(
                FactoryRegistry.ADD, 
                new Compose.Factory());
            
            registry.RegisterOperationFactory2(
                "Inverse", new Inverse.Factory());
        }
    }
}

