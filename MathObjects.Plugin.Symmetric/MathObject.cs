using System;
using System.Linq;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Core.Matrix;
using System.Collections.Generic;
using MathObjects.Core.Matrix.Permutation;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using MathObjects.Plugin.Symmetric.Parser;

namespace MathObjects.Plugin.Symmetric
{
    class MathObject : 
        IMathObject, IHasMatrix, 
        IHasDisplayValue, IHasParseValue
    {
        PermutationMatix value;

        public MathObject()
        {
            this.value = new PermutationMatix(3);
        }

        public MathObject(PermutationMatix value)
        {
            this.value = value;
        }

        public IntegerMatrix Matrix
        {
            get { return this.value; }
        }

        public int[] Values
        {
            get { return value.Switches; }
        }

        public string ParseValue
        {
            get { return DisplayValue; }
            set { this.value = GenerateCycleList(value); }
        }

        public string DisplayValue 
        {
            get { return GenerateCycleList(new PermutationMatix(this.Matrix)); }
        }

        public override string ToString()
        {
            return DisplayValue;
        }

        public class Factory : IMathObjectFactory, IMathObjectMeta
        {
            public IMathObject Create(string param)
            {
                var matrix = new MathObject();

                if (param is string)
                {
                    try
                    {
                        var input = new AntlrInputStream(param);
                        var lexer = new PermutationLexer(input);
                        var tokens = new CommonTokenStream(lexer);
                        var parser = new PermutationParser(tokens);

                        var tree = parser.init(); 

                        var walker = new ParseTreeWalker();
                        var builder = new PermutationBuilder();

                        walker.Walk(builder, tree);

                        matrix = new MathObject(builder.PermutationMatix);
                    }
                    catch(Exception e)
                    {
                        ErrorHandler.SendError(this, e);
                    }
                }

                return matrix;
            }

            public string[] PossibleParameters 
            { 
                get 
                { 
                    return new string[] 
                    {
                        "(1, 2)", "(2, 3)", "(1, 3)", "(1, 2, 3)", "(1, 3, 2)", "(1, 2, 3, 4)",
                        "(3, 4)", "(2, 3, 4)"
                    }; 
                } 
            }
        }
            
        static void Move(List<int> list, List<int> output, int from, int to)
        {
            int v1 = list[from - 1];
            output[to - 1] = v1;
        }

        public static PermutationMatix GenerateCycleList(string value)
        {
            var cycle = CycleList.Create(value);

            if (cycle.CycleSet.Count == 0)
            {
                return new PermutationMatix(PermutationMatix.GetIdentity(3));
            }

            return PermutationMatix.Create(cycle.PermutedList.ToArray());
        }

        public static string GenerateCycleList(PermutationMatix matrix)
        {
            var cycle = CycleList.Create(matrix);

            if (cycle.CycleSet.Count == 0)
            {
                return "( )";
            }

            string s = "";
            foreach(var big in cycle.CycleSet)
            {
                s += "(";
                foreach(var pos in big)
                {
                    if (s.Length > 1)
                    {
                        s += ",";
                    }

                    s += " " + pos;
                }
                s += " )";
            }

            return s;
        }
    }
}

