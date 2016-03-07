using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Registry;
using Antlr4.Runtime;

namespace MathObjects.Plugin.Integers
{
    public class Parser : IParser
    {
        readonly FunctionRegistry registry;

        bool hasError;

        public Parser()
        {
            this.registry = new FunctionRegistry();
        }

        public Parser(FunctionRegistry registry)
        {
            this.registry = registry;
        }

        public bool HasError
        { 
            get { return hasError; } 
            set { hasError = value; }
        }

        public void Parse(string data, IMathObjectStack stack, IMathScope scope)
        {
            var input = new AntlrInputStream(data);
            var lexer = new IntegersLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new IntegersParser(tokens);

            var l = new ErrorListener();
            parser.AddErrorListener(l);

            var tree = parser.stat(); 
            this.hasError = l.HasError;

            if (!l.HasError)
            {
                var init = new InitVisitor(stack, registry);

                init.Visit(tree);

                var eval = new EvalVisitor2(stack, init);

                eval.Visit(tree);
            }
       }
    }
}

