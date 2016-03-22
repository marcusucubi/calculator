using System;
using System.Diagnostics;
using MathObjects.Framework;
using MathObjects.Core.Matrix;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric
{
    class InverseObject : AbstractMathObject, IHasMatrix, IHasDisplayValue
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

                var id = new PermutationMatix(this.target.Matrix.Height);

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
                return MathObject.GenerateCycleList(
                    new PermutationMatix(this.Matrix)); 
            }
        }

        public override string ToString()
        {
            return DisplayValue;
        }
    }
}

