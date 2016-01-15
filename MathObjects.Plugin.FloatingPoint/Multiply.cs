using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.FloatingPoint
{
    public class Multiply : IBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetDouble();
            var rightValue = right.GetDouble();

            var op = new MultiplyObject(leftValue, rightValue);

            return new MathObject(op.Output);
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

