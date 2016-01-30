using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public class ExponentOperation : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetInteger();

            var rightValue = right.GetInteger();

            var op = new ExponentObject(leftValue, rightValue);

            return new MathObject((int)op.Output);
        }
    }
}

