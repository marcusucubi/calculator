using System;
using MathObjects.Framework;

namespace MathObjects.Plugin.Integers
{
    public class Subtract : IMathBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetInteger();
            var rightValue = right.GetInteger();

            var op = new SubtractObject(leftValue, rightValue);

            return new MathObject((int)op.Output);
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
  