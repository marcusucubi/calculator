using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Subtract : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetDouble();
            var rightValue = right.GetDouble();

            var op = new SubtractObject(leftValue, rightValue);

            return new MathObject((double)op.Output);
        }

        public class Factory : IMathBinaryOperationFactory, IHasName
        {
            public string Name
            {
                get { return "-"; }
            }

            public IMathBinaryOperation Create(object parm)
            {
                return new Subtract();
            }
        }
    }
}
  