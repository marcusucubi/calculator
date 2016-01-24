using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class ExponentOperation : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetDouble();

            var rightValue = right.GetDouble();

            var op = new ExponentObject(leftValue, rightValue);

            return new MathObject((double)op.Output);
        }
    }
}

