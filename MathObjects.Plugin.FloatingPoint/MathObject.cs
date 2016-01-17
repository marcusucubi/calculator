using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Plugin.FoatingPoint;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace MathObjects.Plugin.FloatingPoint
{
    class MathObject : IMathObject, IHasOutput, IHasDisplayValue 
    {
        readonly double value;

        public MathObject(double param)
        {
            value = param;
        }

        public object Output
        {
            get { return this.value; }
        }

        public string DisplayValue 
        { 
            get { return this.value.ToString(); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }

        public class Factory : IMathObjectFactory, IMathObjectMeta
        {
            public IMathObject Create(string param)
            {
                double tuple = 0;

                if (param is string)
                {
                    var input = new AntlrInputStream(param);
                    var lexer = new FloatingPointLexer(input);
                    var tokens = new CommonTokenStream(lexer);
                    var parser = new FloatingPointParser(tokens);

                    var l = new ErrorListener();
                    parser.AddErrorListener(l);

                    var tree = parser.stat(); 

                    if (l.HasError)
                    {
                        return null;
                    }

                    var eval = new EvalVisitor();

                    tuple = eval.Visit(tree);
                }

                return new MathObject(tuple);
            }

            public string[] PossibleParameters 
            { 
                get { return new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}; } 
            }
        }
    }
}

