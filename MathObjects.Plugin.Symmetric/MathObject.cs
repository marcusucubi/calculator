using System;
using System.Linq;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Core.Matrix;
using System.Collections.Generic;
using MathObjects.Core.Matrix.Permutation;

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
                    matrix.ParseValue = param as string;
                }

                return matrix;
            }

            public string[] PossibleParameters 
            { 
                get 
                { 
                    return new string[] 
                    {
                        "(1 2)", "(2 3)", "(1 3)", "(1 2 3)", "(1 3 2)", "(1 2 3 4)"
                    }; 
                } 
            }
        }
            
        static void Move(List<int> list, List<int> output, int from, int to)
        {
            int v1 = list[from - 1];
            output[to - 1] = v1;
        }

        static PermutationMatix GenerateCycleList(string value)
        {
            var cycle = CycleList.Create(value);

            if (cycle.CycleSet.Count == 0)
            {
                return new PermutationMatix(PermutationMatix.GetIdentity(3));
            }

            return PermutationMatix.Create(cycle.PermutedList.ToArray());
        }

        static string GenerateCycleList(PermutationMatix matrix)
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
                    s += " " + pos;
                }
                s += " )";
            }

            return s;
        }
    }
}

