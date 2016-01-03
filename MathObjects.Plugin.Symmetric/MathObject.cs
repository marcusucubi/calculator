using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;
using MathObjects.Core.Matrix;

namespace MathObjects.Plugin.Symmetric
{
    class MathObject : 
        IMathObject, IHasMatrix, 
        IHasDisplayValue, IHasParseValue
    {
        PermutationMatix value;

        public MathObject(PermutationMatix param)
        {
            value = param;
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
            set
            {
                var del = new char[]{'(', ')', ' '};
                string clean = value.Trim(del);
                string[] parts = clean.Split(' ');

                var intArray = new int[parts.Length];
                int index = 0;
                foreach(var part in parts)
                {
                    int i = int.Parse(part);
                    intArray[index] = i;
                    index++;
                }

                this.value = PermutationMatix.Create(intArray);
            }
        }

        public string DisplayValue 
        {
            get 
            {
                var switches = this.value.Switches;

                string s = "(";
                foreach(var pos in switches)
                {
                    s += " " + pos;
                }
                s += " )";

                return s;
            }
        }

        public override string ToString()
        {
            return DisplayValue;
        }

        public class Factory : IMathObjectFactory, IMathObjectMeta
        {
            public IMathObject Create(string param)
            {
                var matrix = new MathObject(new PermutationMatix(3));

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
                        "(2 1 3)", "(1 3 2)", "(3 2 1)", "(2 3 1)", "(3 1 2)"
                    }; 
                } 
            }
        }
    }
}

