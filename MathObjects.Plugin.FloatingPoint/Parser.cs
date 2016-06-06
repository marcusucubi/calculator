using System;
using MathObjects.Framework;
using MathObjects.Framework.Parser;
using MathObjects.Framework.Registry;
using MathObjects.Plugin.FoatingPoint;
using Antlr4.Runtime;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Parser : IParser
    {
        readonly FunctionRegistry registry;

        bool hasError;

        public Parser(FunctionRegistry registry)
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
            var lexer = new FloatingPointLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new FloatingPointParser(tokens);

            var l = new ErrorListener();
            parser.AddErrorListener(l);

            var file = parser.file();

            foreach (var stat in file.stat())
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

