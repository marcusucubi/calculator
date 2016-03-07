using System;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Registry;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MathObjects.Plugin.Symmetric.Parser;
using MathObjects.Framework;

namespace MathObjects.Plugin.Symmetric.Parser
{
    public class Parser2 : IParser
    {
        public bool HasError
        {
            get { return false; }
        }

        public void Parse(string data, IMathObjectStack stack, IMathScope scope)
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
                var eval = new EvalVisitor2(stack);

                eval.Visit(tree);
            }

        }
    }
}

