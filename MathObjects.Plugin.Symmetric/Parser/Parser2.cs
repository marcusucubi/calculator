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
        readonly FunctionRegistry registry;

        bool hasError;

        public Parser2(FunctionRegistry registry)
        {
            this.registry = registry;
        }

        public bool HasError
        { 
            get { return hasError; } 
            set { hasError = value; }
        }

        public void Parse(
            string data, 
            IMathObjectStack stack, 
            IMathScope scope)
        {
            if (!data.TrimEnd().EndsWith(";"))
            {
                data = data + ";";
            }

            var input = new AntlrInputStream(data);
            var lexer = new PermutationLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PermutationParser(tokens);

            var l = new ErrorListener();
            parser.AddErrorListener(l);

            var file = parser.file();

            foreach (var stat in file.init())
            {
                this.hasError = l.HasError;

                if (!l.HasError)
                {
                    var processor = new Processor(
                        stack, scope, this.registry);

                    var test = new GenericVisitor<IMathObject>(
                        processor);

                    test.Visit(stat);
                }
            }

            if (l.HasError)
            {
                throw new ParserException(l.Descriptions);
            }
        }
    }
}

