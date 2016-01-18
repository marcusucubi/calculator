using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Registry;
using Antlr4.Runtime;

namespace MathObjects.Plugin.Rational
{
    public class Parser : IParser
    {
        public void Parse(string data, IMathObjectStack stack, FactoryRegistry registry)
        {
            var input = new AntlrInputStream(data);
            var lexer = new RationalLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new RationalParser(tokens);

            var l = new ErrorListener();
            parser.AddErrorListener(l);

            var tree = parser.stat(); 

            if (!l.HasError)
            {
                var eval = new EvalVisitor2(registry, stack);
                
                eval.Visit(tree);
            }
       }
    }
}

