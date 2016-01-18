using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.Rational
{
    public class Multiply : IBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetTuple();
            var rightValue = right.GetTuple();

            var op = new MultiplyObject(leftValue, rightValue);

            return new MathObject(op.Output as Tuple<int, int>);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Multiply"; }
            }

            public IBinaryOperation Create(object parm)
            {
                return new Multiply();
            }
        }
    }
}

