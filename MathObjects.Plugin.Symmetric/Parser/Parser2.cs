using System;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Registry;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MathObjects.Plugin.Symmetric.Parser;

namespace MathObjects.Plugin.Symmetric.Parser
{
    public class Parser2 : IParser
    {
        readonly FactoryRegistry registry;

        public Parser2(FactoryRegistry registry)
        {
            this.registry = registry;
        }

        public bool HasError
        {
            get { return false; }
        }

        public void Parse(string data, IMathObjectStack stack)
        {
            var input = new AntlrInputStream(data);
            var lexer = new PermutationLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PermutationParser(tokens);

            var l = new ErrorListener();
            parser.AddErrorListener(l);

            var tree = parser.init(); 

            if (!l.HasError)
            {
                var eval = new EvalVisitor2(registry, stack);

                eval.Visit(tree);
            }

        }
    }
}

