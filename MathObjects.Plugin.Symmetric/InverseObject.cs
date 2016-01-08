using System;
using MathObjects.Framework;
using System.Diagnostics;
using MathObjects.Core.Matrix;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric
{
    class InverseObject : IMathObject, IHasMatrix, IHasDisplayValue
    {
        readonly IHasMatrix target;

        public InverseObject(IHasMatrix value)
        {
            if (value == null)
            {
                throw new Exception();
            }

            this.target = value;
        }

        public IntegerMatrix Matrix
        {
            get 
            {
                var obj = new GenInverse();

                var id = new PermutationMatix(3);

                obj.Generate(this.target.Matrix);

                var result = obj.ElementaryArray.Multiply(id);

                var temp = new PermutationMatix(result);

                return temp; 
            }
        }

        public string DisplayValue 
        {
            get 
            {
                var switches = (this.Matrix as PermutationMatix).Switches;

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
    }
}

