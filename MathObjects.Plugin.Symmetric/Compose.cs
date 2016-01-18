using System;
using MathObjects.Framework;
using MathObjects.Core.Matrix;
using MathObjects.Core.Matrix.Permutation;

namespace MathObjects.Plugin.Symmetric
{
    class Compose : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            IntegerMatrix leftValue = null;
            IntegerMatrix rightValue = null;

            if (left is IHasMatrix)
            {
                leftValue = (left as IHasMatrix).Matrix;
            }
            else if (left is IHasOutput)
            {
                var temp = (left as IHasOutput).Output;
                leftValue = (temp as IHasMatrix).Matrix;
            }

            if (right is IHasMatrix)
            {
                rightValue = (right as IHasMatrix).Matrix;
            }
            else if (right is IHasOutput)
            {
                var temp = (right as IHasOutput).Output;
                rightValue = (temp as IHasMatrix).Matrix;
            }

            if (leftValue.Height > rightValue.Height)
            {
                uint v = (uint)(leftValue.Height - rightValue.Height);
                rightValue = rightValue.Expand(v);
            }

            if (rightValue.Height > leftValue.Height)
            {
                uint v = (uint)(rightValue.Height - leftValue.Height);
                leftValue = leftValue.Expand(v);
            }

            var result = leftValue.MultiplyBy(rightValue);

            return new MathObject(new PermutationMatix(result));
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Compose"; }
            }

            public IMathBinaryOperation Create(object parm)
            {
                return new Compose();
            }
        }
    }
}

