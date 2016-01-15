using System;
using MathObjects.Framework;
using MathObjects.Framework.Registry;

namespace MathObjects.Plugin.FloatingPoint
{
    class Add : IBinaryOperation
    {
        public IMathObject Perform(IMathObject left, IMathObject right)
        {
            var leftValue = left.GetDouble();
            var rightValue = right.GetDouble();

            var op = new AddObject(leftValue, rightValue);

            return new MathObject(op.Output);
        }

        public class Factory : IMathOperationFactory, IHasName
        {
            public string Name
            {
                get { return "Add"; }
            }

            public IBinaryOperation Create(object parm)
            {
                return new Add();
            }
        }
    }
}

